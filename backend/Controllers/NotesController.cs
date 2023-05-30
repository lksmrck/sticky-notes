using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public NotesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return await _db.Notes.ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _db.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            _db.Entry(note).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _db.Notes.Add(note);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.Id }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _db.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _db.Notes.Remove(note);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteExists(int id)
        {
            return _db.Notes.Any(e => e.Id == id);
        }
    }
}
