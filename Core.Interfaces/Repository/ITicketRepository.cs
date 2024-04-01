
using Core.Entities.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public  interface ITicketRepository
    {
        public Task<IEnumerable<Ticket>> GetAll();
        public Task<Ticket> Get(Guid id);
        public Task<IEnumerable<Ticket>> Find(Expression<Func<Ticket, bool>> expression);
        public Ticket Add(Ticket ticket);
        public IEnumerable<Ticket> AddRange(IEnumerable<Ticket> tickets);
        public Ticket Update(Ticket ticket, Guid id);
        public void Delete(Guid id);
        public void DeleteRange(IEnumerable<Ticket> tickets);
    }
}
