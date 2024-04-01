
using Ardalis.GuardClauses;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Context;
using System;

namespace Persistence.Data.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ConcertDbContext _context;

        public ShoppingCartRepository(ConcertDbContext context)
        {
            _context = context;
        }

        public ShoppingCart Add(ShoppingCart shoppingCart)
        {
            Guard.Against.Null(shoppingCart, nameof(ShoppingCart));

            shoppingCart.DateCreated = DateTime.UtcNow;
            _context.ShoppingCarts.Add(shoppingCart);
            _context.SaveChanges();
            return shoppingCart;
        }

        public void Delete(Guid id)
        {
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(shoppingCart, nameof(shoppingCart));

            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();
        }

        public async Task<ShoppingCart> Get(Guid id)
        {
            return await _context.ShoppingCarts.FindAsync(id);
        }

        public async Task<ShoppingCart> GetByUserId(Guid userId)
        {
            return await _context.ShoppingCarts.Include(x => x.Owner).FirstAsync(x => x.Owner.Id.Equals(userId));
        }

        public ShoppingCart Update(ShoppingCart shoppingCart, Guid id)
        {
            var entity = _context.ShoppingCarts.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(shoppingCart, nameof (shoppingCart));
            Guard.Against.Null(entity, nameof(entity));

            shoppingCart.LastUpdated = DateTime.UtcNow;
            _context.Entry(entity).CurrentValues.SetValues(shoppingCart);
            _context.SaveChanges();
            return shoppingCart;
        }
    }
}
