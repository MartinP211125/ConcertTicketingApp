
using Core.Entities.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> Get(Guid id);
        public Task<IEnumerable<User>> Find(Expression<Func<User, bool>> expression);
        public User Add(User user);
        public IEnumerable<User> AddRange(IEnumerable<User> users);
        public User Update(User user, Guid id);
        public void Delete(Guid id);
        public void DeleteRange(IEnumerable<User> users);
    }
}
