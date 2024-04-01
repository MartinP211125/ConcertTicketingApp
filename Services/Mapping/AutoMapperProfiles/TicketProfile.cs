
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;

namespace Services.Mapping.AutoMapperProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile() { 
            CreateMap<Ticket, TicketDTO>().ReverseMap();
        }
    }
}
