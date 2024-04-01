
using Ardalis.GuardClauses;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Context;
using System;
using System.Linq.Expressions;

namespace Persistence.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConcertDbContext _context;
        public UserRepository(ConcertDbContext context)
        {
            _context = context;
        }
        public User Add(User user)
        {
            Guard.Against.Null(user, nameof(user));

            user.DateCreated = DateTime.UtcNow;
            _context.Users.Add(user);  
            _context.SaveChanges();
            return user;
        }

        public IEnumerable<User> AddRange(IEnumerable<User> users)
        {
            Guard.Against.Null(users, nameof(users));

            _context.Users.AddRange(users);
            _context.SaveChanges();
            return users;
        }

        public void Delete(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            Guard.Against.Null(user, nameof(user));

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<User> users)
        {
            Guard.Against.Null(users, nameof(users));

            _context.Users.RemoveRange(users);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> Find(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Where(expression).ToListAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public User Update(User user, Guid id)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Id == id);
            Guard.Against.Null(user, nameof(user));
            Guard.Against.Null(entity, nameof(entity));

            user.LastUpdated = DateTime.UtcNow;
            _context.Entry(entity).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return user;
        }
    }
}
