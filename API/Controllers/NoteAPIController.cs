using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using backend.Models;

using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using backend.Models.DTO;
using AutoMapper;
using API.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Domain.Note;
using Notes.Validation.Services.Interfaces;
using Persistence;
using Application.Interfaces;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ApplicationDbContext _db;
        private readonly INoteRepository _dbNote;
        private readonly IMapper _mapper;
        private readonly INoteValidationService _validationService;

        public NoteAPIController(ApplicationDbContext db, INoteRepository dbNote, IMapper mapper, INoteValidationService validationService)
        {
            _response = new APIResponse();
            _db = db;
            _dbNote = dbNote;
            _mapper = mapper;
            _validationService = validationService;
        }

        // GET: api/Notes
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetNotes()
        {

            try
            {
                IEnumerable<Note> notesList;

                notesList = await _dbNote.GetAllAsync();


                _response.Result = _mapper.Map<List<NoteDto>>(notesList);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                //TODO: check this
                _response.ErrorMessages.Add(ex.ToString());
            }

            return _response;
        }

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "GetNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetNote(int id)
        {

            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var note = await _dbNote.GetAsync(u => u.Id == id);

                if (note == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                //TODO: pridat mapper na NoteDTO
                _response.Result = _mapper.Map<NoteDto>(note);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                //TODO: check this
                _response.ErrorMessages.Add(ex.ToString());
            }

            return _response;
        }

        // POST: api/Notes
        [HttpPost]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateNote([FromBody] NoteCreateDto createDto)
        {
            try
            {
                if (await _dbNote.GetAsync(u => u.Heading.ToLower() == createDto.Heading.ToLower()) != null)
                {
                    ModelState.AddModelError("Custom Error", "Note With Same Heading Already Exists");
                    return BadRequest(ModelState);
                };

                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                Note note = _mapper.Map<Note>(createDto);

                var validationResult = _validationService.ValidateNote(note);

                if (validationResult.IsValid == false)
                {
                    return BadRequest(validationResult);
                }

                await _dbNote.CreateAsync(note);

                _response.Result = _mapper.Map<NoteDto>(note);
                _response.StatusCode = HttpStatusCode.Created;

                return _response;
                //return CreatedAtRoute("GetNote", new { id = note.Id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                //TODO: check this
                _response.ErrorMessages.Add(ex.ToString());
            }

            return _response;
        }


        // PUT: api/Notes/5
        [HttpPut("{id}", Name = "UpdateNote")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateNote(int id, [FromBody] NoteUpdateDto updateDto)
        {
            try
            {
                Note note = _mapper.Map<Note>(updateDto);

                if (updateDto == null || id != updateDto.Id)
                {
                    return BadRequest();
                }

                //Note note =  _mapper.Map<Note>(updateDto);

                await _dbNote.UpdateAsync(note);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                //TODO: check this
                _response.ErrorMessages.Add(ex.ToString());
            }

            return _response;
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}", Name = "DeleteNote")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteNote(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var foundNote = await _dbNote.GetAsync(u => u.Id == id);

                if (foundNote == null)
                {
                    return NotFound();
                }

                await _dbNote.RemoveAsync(foundNote);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                //TODO: check this
                _response.ErrorMessages.Add(ex.ToString());
            }

            return _response;
        }


    }
}
