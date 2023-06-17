using API.Models.DTO;
using API.Repository.IRepository;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace API.Controllers
{ 
    // api/Users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    private readonly IUserRepository _userRepo;
    protected APIResponse _response; 

    public UsersController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
        _response = new APIResponse();  
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
    {
        var loginResponse = await _userRepo.Login(model);
        if(loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token)) 
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Username or password is incorrect");
            return BadRequest(_response);
        }

        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        _response.Result = loginResponse;
        return Ok(_response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Registration([FromBody] RegistrationRequestDto model)
    {
        bool isUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
        if (!isUserNameUnique)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("User already exists");
            return BadRequest(_response);
        }

        var user = await _userRepo.Register(model);

        if (user == null)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Error while registering");
            return BadRequest(_response);
        }

        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        return Ok(_response);
    }

    }
}
