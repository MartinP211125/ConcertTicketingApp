
using Ardalis.GuardClauses;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Context;
using System;
using System.Linq.Expressions;

namespace Persistence.Data.Repositories
{
    public class TicketInShoppingCartRepository : ITicketInShoppingCartRepository
    {
        private readonly ConcertDbContext _context;
        public TicketInShoppingCartRepository(ConcertDbContext context)
        {
            _context = context;
        }
        
        public TicketInShoppingCart Add(TicketInShoppingCart ticketInShoppingCart)
        {
            Guard.Against.Null(ticketInShoppingCart);

            ticketInShoppingCart.DateCreated = DateTime.UtcNow;
            _context.TicketsInShoppingCart.Add(ticketInShoppingCart);
            _context.SaveChanges();
            return ticketInShoppingCart;
        }

        public void Delete(Guid id)
        {
            var ticketInShoppingCart = _context.TicketsInShoppingCart.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(ticketInShoppingCart, nameof(ticketInShoppingCart));

            _context.TicketsInShoppingCart.Remove(ticketInShoppingCart);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TicketInShoppingCart>> Find(Expression<Func<TicketInShoppingCart, bool>> expression)
        {
            var ticketInShoppingCart = await _context.TicketsInShoppingCart.Where(expression).ToListAsync();
            return ticketInShoppingCart;

        }

        public async Task<TicketInShoppingCart> Get(Guid id)
        {
            return await _context.TicketsInShoppingCart.FindAsync(id);
        }

        public async Task<TicketInShoppingCart> Get(Guid ticketId, Guid shoppingCartId)
        {
            return await _context.TicketsInShoppingCart.FirstAsync(x => (x.TicketId == ticketId && x.ShoppingCartId == shoppingCartId));
        }

        public TicketInShoppingCart Update(TicketInShoppingCart ticketInShoppingCart, Guid id)
        {
            var entity = _context.TicketsInShoppingCart.FirstOrDefault(x=> x.Id == id);
            Guard.Against.Null(ticketInShoppingCart, nameof(ticketInShoppingCart));
            Guard.Against.Null(entity, nameof(entity));

            ticketInShoppingCart.LastUpdated = DateTime.UtcNow;
            _context.TicketsInShoppingCart.Entry(entity).CurrentValues.SetValues(ticketInShoppingCart);
            _context.SaveChanges();
            return ticketInShoppingCart;
        }
    }
}
