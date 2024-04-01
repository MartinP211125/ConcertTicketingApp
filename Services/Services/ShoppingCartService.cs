using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Services.Interfaces.Services;

namespace Services.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _repository;
        private readonly IMapper _mapper;
        public ShoppingCartService(IShoppingCartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ShoppingCartDTO Create()
        {
            var shoppingCartDTO = new ShoppingCartDTO
            {
                Id = Guid.NewGuid()
            };
            var shoppignCart = _mapper.Map<ShoppingCart>(shoppingCartDTO);

            return _mapper.Map<ShoppingCartDTO>(_repository.Add(shoppignCart));
        }

        public async Task<ShoppingCartDTO> Get(Guid id)
        {
           var shoppingCart = await _repository.Get(id);

           return _mapper.Map<ShoppingCartDTO>(shoppingCart);
        }
    }
}
