using backend.Models;

namespace API.Models.DTO
{
    public class LoginResponseDto
    {
        public /*LocalUser*/UserDto User { get; set; }
        public string Token { get; set; }
    }
}
