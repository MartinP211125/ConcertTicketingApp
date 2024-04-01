
using Core.DTOs;

namespace Services.Interfaces.Services
{
    public interface ITicketInOrderService
    {
        public Task<IEnumerable<TicketInOrderDTO>> GetAll(Guid userId);
        public Task<IEnumerable<TicketInOrderDTO>> Create(Guid userId);
        public void RemoveRange(ICollection<TicketInOrderDTO> items);
        public Task Remove(Guid ticketId, Guid userId);
        public Task<TicketInOrderDTO> Update(Guid ticketId, Guid userId, int quantity);
    }
}
