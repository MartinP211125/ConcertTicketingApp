
using Core.DTOs;

namespace Services.Interfaces.Services
{
    public interface ITicketInShoppingCartService
    {
        public Task<IEnumerable<TicketInShoppingCartDTO>> GetAll(Guid userId);
        public Task<TicketInShoppingCartDTO> Create(Guid ticketId, Guid userId, int quantity);
        public void RemoveRange(IEnumerable<TicketInShoppingCartDTO> items);
        public Task Remove(Guid ticketId, Guid userId);
        public Task<TicketInShoppingCartDTO> Update(Guid ticketId, Guid userId, int quantity);
    }
}
