using API.Models;
using API.Models.DTO;
using AutoMapper;
using backend.Models;
using backend.Models.DTO;
using Domain.Note;
using Domain.Users;

namespace API
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            CreateMap<Note, NoteDto>().ReverseMap();

            CreateMap<Note, NoteCreateDto>().ReverseMap();
            CreateMap<Note, NoteUpdateDto>().ReverseMap();

            CreateMap<LocalUser, RegistrationRequestDto>().ReverseMap();
            CreateMap<LocalUser, LoginRequestDto>().ReverseMap();

            CreateMap<ApplicationUser, UserDto>().ReverseMap();

        }
    }
}
