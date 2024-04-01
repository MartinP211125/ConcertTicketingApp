
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;

namespace Services.Mapping.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() {
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
