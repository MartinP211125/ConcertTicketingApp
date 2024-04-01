
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;

namespace Services.Mapping.AutoMapperProfiles
{
    public class TicketInShoppingCartProfile : Profile
    {
        public TicketInShoppingCartProfile()
        {
            CreateMap<TicketInShoppingCart, TicketInShoppingCartDTO>().ReverseMap();
        }
    }
}
