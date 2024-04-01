
using Ardalis.GuardClauses;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Context;
using System.Linq.Expressions;

namespace Persistence.Data.Repositories
{
    public class TicketInOrderRepository : ITicketInOrderRepository
    {
        private ConcertDbContext _context;
        public TicketInOrderRepository(ConcertDbContext context)
        {
            _context = context;
        }

        public TicketInOrder Add(TicketInOrder ticketInOrder)
        {
            Guard.Against.Null(ticketInOrder, nameof(ticketInOrder));

            ticketInOrder.DateCreated = DateTime.UtcNow;
            _context.TicketsInOrder.Add(ticketInOrder);
            _context.SaveChanges();
            return ticketInOrder;
        }
        public IEnumerable<TicketInOrder> AddRange(IEnumerable<TicketInOrder> ticketsInOrder)
        {
            Guard.Against.NullOrEmpty(ticketsInOrder, nameof(ticketsInOrder));
            foreach(var ticketInOrder in ticketsInOrder)
            {
                ticketInOrder.DateCreated = DateTime.UtcNow;
            }
            _context.TicketsInOrder.AddRange(ticketsInOrder);
            _context.SaveChanges();
            return ticketsInOrder;
        }


        public void Delete(Guid id)
        {
            var ticketInOrder = _context.TicketsInOrder.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(ticketInOrder, nameof(ticketInOrder));

            _context.TicketsInOrder.Remove(ticketInOrder);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TicketInOrder>> Find(Expression<Func<TicketInOrder, bool>> expression)
        {
            var ticketInOrder = await _context.TicketsInOrder.Where(expression).ToListAsync();
            return ticketInOrder;
        }

        public async Task<TicketInOrder> Get(Guid id)
        {
            return await _context.TicketsInOrder.FindAsync(id);
        }

        public async Task<TicketInOrder> Get(Guid ticketId, Guid orderId)
        {
            return await _context.TicketsInOrder.FirstAsync(x => (x.TicketId == ticketId && x.OrderId == orderId));
        }

        public TicketInOrder Update(TicketInOrder ticketInOrder, Guid id)
        {
            var entity = _context.TicketsInOrder.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(ticketInOrder, nameof (ticketInOrder));
            Guard.Against.Null(entity, nameof (entity));

            ticketInOrder.LastUpdated = DateTime.UtcNow;
            _context.TicketsInOrder.Entry(entity).CurrentValues.SetValues(ticketInOrder);
            _context.SaveChanges();
            return ticketInOrder;
        }
    }
}
