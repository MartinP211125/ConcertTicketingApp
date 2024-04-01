
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Services.Interfaces.Services;

namespace Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderReposiroty _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderReposiroty orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public OrderDTO Create()
        {
            var orderDTO = new OrderDTO
            {
                Id = Guid.NewGuid()
            };
            var order = _mapper.Map<Order>(orderDTO);

            return _mapper.Map<OrderDTO>(_orderRepository.Add(order));
        }

        public async Task<OrderDTO> Get(Guid id)
        {
            var order = await _orderRepository.Get(id);

            return _mapper.Map<OrderDTO>(order);
        }
    }
}
