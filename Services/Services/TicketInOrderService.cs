
using Ardalis.GuardClauses;
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Services.Interfaces.Services;

namespace Services.Services
{
    public class TicketInOrderService : ITicketInOrderService
    {
        private readonly ITicketInOrderRepository _ticketInOrderRepository;
        private readonly IUserService _userService;
        private readonly ITicketInShoppingCartService _ticketInShoppingCartService;
        private readonly IMapper _mapper;

        public TicketInOrderService(ITicketInOrderRepository ticketInOrderRepository, IUserService userService, IMapper mapper, ITicketInShoppingCartService ticketInShoppingCartService)
        {
            _ticketInOrderRepository = ticketInOrderRepository;
            _userService = userService;
            _mapper = mapper;
            _ticketInShoppingCartService = ticketInShoppingCartService;
        }
    
        public async Task<IEnumerable<TicketInOrderDTO>> Create(Guid userId)
        {
            var ticketsInShoppingCart = await _ticketInShoppingCartService.GetAll(userId);
            Guard.Against.NullOrEmpty(ticketsInShoppingCart, nameof(ticketsInShoppingCart));

            var userOrderId = (await _userService.Get(userId)).OrderId;
            Guard.Against.Null(userOrderId, nameof(userOrderId));

            var ticketsInOrder = ticketsInShoppingCart.Select(x => new TicketInOrder()
            {
                Id = Guid.NewGuid(),
                TicketId = x.TicketId,
                Quantity = x.Quantity,
                OrderId = userOrderId
            }).ToList();

            _ticketInShoppingCartService.RemoveRange(ticketsInShoppingCart);
            return _mapper.Map<IEnumerable<TicketInOrderDTO>>(_ticketInOrderRepository.AddRange(ticketsInOrder));
        }

        public async Task<IEnumerable<TicketInOrderDTO>> GetAll(Guid userId)
        {
            var user = await _userService.Get(userId);
            Guard.Against.Null(user, nameof(user));

            var orderId = user.OrderId;
            Guard.Against.Null(orderId, nameof(orderId));

            var ticketsInOrder = await _ticketInOrderRepository.Find(x => x.OrderId == orderId);
            var ticketInOrderDTO = _mapper.Map<IEnumerable<TicketInOrderDTO>>(ticketsInOrder);
            return ticketInOrderDTO;
        }

        public async Task Remove(Guid ticketId, Guid userId)
        {
            var userOrderId = (await _userService.Get(userId)).OrderId;
            Guard.Against.Null(userOrderId, nameof(userOrderId));

            var ticketInOrder = (await _ticketInOrderRepository.Find(x => x.TicketId == ticketId && x.OrderId == userOrderId)).FirstOrDefault();
            Guard.Against.Null(ticketInOrder, nameof(ticketInOrder));

            _ticketInOrderRepository.Delete(ticketInOrder.Id);
        }

        public void RemoveRange(ICollection<TicketInOrderDTO> items)
        {
            foreach (var item in items)
            {
                _ticketInOrderRepository.Delete(item.Id);
            }
        }

        public async Task<TicketInOrderDTO> Update(Guid ticketId, Guid userId, int quantity)
        {
            var userOrderId = (await _userService.Get(userId)).OrderId;
            var ticketInOrder = (await _ticketInOrderRepository.Find(x => x.TicketId == ticketId && x.OrderId == userOrderId)).FirstOrDefault();
            Guard.Against.Null(ticketInOrder, nameof(ticketInOrder));

            ticketInOrder.Quantity = quantity;

            return _mapper.Map<TicketInOrderDTO>(_ticketInOrderRepository.Update(ticketInOrder, ticketInOrder.Id));
        }
    }
}
