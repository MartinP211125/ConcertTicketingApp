
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;

namespace Services.Mapping.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserDTO>().ReverseMap();  
        }
    }
}
