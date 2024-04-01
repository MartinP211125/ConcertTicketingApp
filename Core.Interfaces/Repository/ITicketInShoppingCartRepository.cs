
using Core.Entities.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface ITicketInShoppingCartRepository
    {
        public Task<TicketInShoppingCart> Get(Guid id);
        public Task<TicketInShoppingCart> Get(Guid ticketId, Guid shoppingCartId);
        public TicketInShoppingCart Add(TicketInShoppingCart ticketInShoppingCart);
        public TicketInShoppingCart Update(TicketInShoppingCart ticketInShoppingCart, Guid id);
        public Task<IEnumerable<TicketInShoppingCart>> Find(Expression<Func<TicketInShoppingCart, bool>> expression);
        public void Delete(Guid id);
    }
}
