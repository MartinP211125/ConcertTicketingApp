
using Core.Entities.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface ITicketInOrderRepository
    {
        public Task<TicketInOrder> Get(Guid id);
        public Task<TicketInOrder> Get(Guid ticketId, Guid orderId);
        public TicketInOrder Add(TicketInOrder ticketInOrder);
        public IEnumerable<TicketInOrder> AddRange(IEnumerable<TicketInOrder> ticketsInOrder);
        public TicketInOrder Update(TicketInOrder ticketInOrder, Guid id);
        public Task<IEnumerable<TicketInOrder>> Find(Expression<Func<TicketInOrder, bool>> expression);
        public void Delete(Guid id);
    }
}
