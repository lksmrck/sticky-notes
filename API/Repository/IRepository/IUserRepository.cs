using API.Models.DTO;
using backend.Models;

namespace API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDto> Login(LoginRequestDto lognRequestDto);
        Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
    }
}
