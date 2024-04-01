using Ardalis.GuardClauses;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Context;
using System;
using System.Linq.Expressions;
using System.Runtime.Versioning;

namespace Persistence.Data.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly ConcertDbContext _context;
        public ConcertRepository(ConcertDbContext context)
        {
            _context = context;
        }
        public Concert Add(Concert concert)
        {
            Guard.Against.Null(concert, nameof(concert));

            concert.DateCreated = DateTime.UtcNow;
            _context.Concerts.Add(concert);
           _context.SaveChanges();
           return concert;
        }

        public IEnumerable<Concert> AddRange(IEnumerable<Concert> concerts)
        {
            Guard.Against.Null(concerts, nameof(concerts));

            _context.Concerts.AddRange(concerts);
            _context.SaveChanges();
            return concerts;
        }

        public void Delete(Guid id)
        {
            var concert = _context.Concerts.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(concert, nameof(concert));

            _context.Concerts.Remove(concert);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<Concert> concerts)
        {
            Guard.Against.Null(concerts, nameof(concerts));

            _context.Concerts.RemoveRange(concerts);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Concert>> Find(Expression<Func<Concert, bool>> expression)
        {
           return await _context.Concerts.Where(expression).ToListAsync();
        }

        public async Task<Concert> Get(Guid id)
        {
            return await _context.Concerts.FindAsync(id);
        }

        public async Task<IEnumerable<Concert>> GetAll()
        {
            return await _context.Concerts.ToListAsync();
        }

        public Concert Update(Concert concert, Guid id)
        {
            var entity = _context.Concerts.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.Null(entity, nameof(entity));

            concert.LastUpdated = DateTime.UtcNow;
            _context.Entry(entity).CurrentValues.SetValues(concert);
            _context.SaveChanges();
            return entity;
        }
    }
}
