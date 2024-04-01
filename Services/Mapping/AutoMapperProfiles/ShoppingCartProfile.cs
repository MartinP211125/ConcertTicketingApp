
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;

namespace Services.Mapping.AutoMapperProfiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile() {
            CreateMap<ShoppingCart, ShoppingCartDTO>().ReverseMap();
        }
    }
}
