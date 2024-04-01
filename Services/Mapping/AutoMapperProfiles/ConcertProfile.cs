
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;

namespace Services.Mapping.AutoMapperProfiles
{
    public class ConcertProfile : Profile
    {
        public ConcertProfile() { 
            CreateMap<Concert, ConcertDTO>().ReverseMap();
        }
    }
}
