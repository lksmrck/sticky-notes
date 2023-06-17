using API.Models.DTO;
using API.Repository.IRepository;
using Azure;
using backend.Data;
using backend.Models;
using backend.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;

        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsUniqueUser(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);

            if(user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDto.UserName.ToLower() && x.Password == loginRequestDto.Password);

            if (user == null) 
            {
                return new LoginResponseDto()
                {
                    User = null,
                    Token = ""
                };
            }

            // if user was found generate JWT Token

            var tokenHandler = new JwtSecurityTokenHandler();
            // Converts string into bytes array
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Define token, which will be created 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    //new Claim(ClaimTypes.Name,user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = user,
                Token = tokenHandler.WriteToken(token)
            };

            return loginResponseDto;

        }

        public async Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registrationRequestDto.UserName,
                Password = registrationRequestDto.Password,
                Name = registrationRequestDto.Name,
            };

            //LocalUser user = _mapper.Map<LocalUser>(registrationRequestDto);

            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();

            user.Password = "";

            return user;
        }
    }
}
