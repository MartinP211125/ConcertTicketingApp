
using Ardalis.GuardClauses;
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Services.Interfaces.Services;
using System.Xml.Linq;

namespace Services.Services
{
    public class TicketInShoppingCartService : ITicketInShoppingCartService
    {
        private readonly ITicketInShoppingCartRepository _ticketInShoppingCartRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TicketInShoppingCartService(ITicketInShoppingCartRepository ticketInShoppingCartRepository, IMapper mapper, IUserService userService)
        {
            _ticketInShoppingCartRepository = ticketInShoppingCartRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<TicketInShoppingCartDTO> Create(Guid ticketId, Guid userId, int quantity)
        {
            var user = await _userService.Get(userId);
            Guard.Against.Null(user, nameof(user));

            var userShoppingCartId = user.ShoppingCartId;
            Guard.Against.Null(userShoppingCartId, nameof(userShoppingCartId));

            var ticketInShoppingCartDTO = new TicketInShoppingCartDTO
            {
                Id = Guid.NewGuid(),
                TicketId = ticketId,
                Quantity = quantity,
                ShoppingCartId = userShoppingCartId
            };

            var ticketInShoppingCart = _mapper.Map<TicketInShoppingCart>(ticketInShoppingCartDTO);

            return _mapper.Map<TicketInShoppingCartDTO>(_ticketInShoppingCartRepository.Add(ticketInShoppingCart));
        }

        public async Task<IEnumerable<TicketInShoppingCartDTO>> GetAll(Guid userId)
        {
            var user = await _userService.Get(userId);
            Guard.Against.Null(user, nameof(user));

            var shoppingCartId = user.ShoppingCartId;  
            Guard.Against.Null(shoppingCartId, nameof(shoppingCartId));

            var ticketsInShoppingCart = await _ticketInShoppingCartRepository.Find(x => x.ShoppingCartId == shoppingCartId);
            var ticketsInShoppingCartDTO = _mapper.Map<IEnumerable<TicketInShoppingCartDTO>>(ticketsInShoppingCart);
            return ticketsInShoppingCartDTO;
        }

        public async Task Remove(Guid ticketId, Guid userId)
        {
            var user = await _userService.Get(userId);
            Guard.Against.Null(user, nameof(user));

            var shoppingCartId = user.ShoppingCartId;
            Guard.Against.Null(shoppingCartId, nameof(shoppingCartId));

            var ticketInShoppingCart = (await _ticketInShoppingCartRepository.Find(x => x.TicketId == ticketId && x.ShoppingCartId == shoppingCartId)).FirstOrDefault();
            Guard.Against.Null(ticketInShoppingCart, nameof(ticketInShoppingCart));

            _ticketInShoppingCartRepository.Delete(ticketInShoppingCart.Id);
        }

        public void RemoveRange(IEnumerable<TicketInShoppingCartDTO> items)
        {
            foreach (var item in items)
            {
                _ticketInShoppingCartRepository.Delete(item.Id);
            }
        }

        public async Task<TicketInShoppingCartDTO> Update(Guid ticketId, Guid userId, int quantity)
        {
            var user = await _userService.Get(userId);
            Guard.Against.Null(user, nameof(user));

            var shoppingCartId = user.ShoppingCartId;
            Guard.Against.Null(shoppingCartId, nameof(shoppingCartId));

            var ticketInShoppingCart = (await _ticketInShoppingCartRepository.Find(x => x.TicketId == ticketId && x.ShoppingCartId == shoppingCartId)).FirstOrDefault();
            Guard.Against.Null(ticketInShoppingCart, nameof(ticketInShoppingCart));

            ticketInShoppingCart.Quantity = quantity;

            return _mapper.Map<TicketInShoppingCartDTO>(_ticketInShoppingCartRepository.Update(ticketInShoppingCart, ticketInShoppingCart.Id));
        }
    }
}
