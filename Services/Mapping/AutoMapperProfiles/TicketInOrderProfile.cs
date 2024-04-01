
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;

namespace Services.Mapping.AutoMapperProfiles
{
    public class TicketInOrderProfile : Profile
    {
        public TicketInOrderProfile() { 
            CreateMap<TicketInOrder, TicketInOrderDTO>().ReverseMap();
        }
    }
}
