
using Ardalis.GuardClauses;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Context;
using System;

namespace Persistence.Data.Repositories
{
    public class OrderRepository : IOrderReposiroty
    {
        private readonly ConcertDbContext _context;
        public OrderRepository(ConcertDbContext context)
        {
            _context = context;
        }

        public Order Add(Order order)
        {
            Guard.Against.Null(order, nameof(order));

            order.DateCreated = DateTime.UtcNow;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void Delete(Guid id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            Guard.Against.Null(order, nameof(order));

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public async Task<Order> Get(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> GetByUserId(Guid userId)
        {
            return await _context.Orders.Include(x => x.Owner).FirstAsync(x => x.Owner.Id == userId);
        }

        public Order Update(Order order, Guid id)
        {
            var entity = _context.Orders.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(order, nameof (order));
            Guard.Against.Null(entity, nameof(entity));

            order.LastUpdated = DateTime.UtcNow;
            _context.Orders.Entry(entity).CurrentValues.SetValues(order);
            _context.SaveChanges();
            return order;
        }
    }
}
