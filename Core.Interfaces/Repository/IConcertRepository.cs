
using Core.Entities.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface IConcertRepository
    {
        public Task<IEnumerable<Concert>> GetAll();
        public Task<Concert> Get(Guid id);
        public Task<IEnumerable<Concert>> Find(Expression<Func<Concert, bool>> expression); 
        public Concert Add(Concert concert);
        public IEnumerable<Concert> AddRange(IEnumerable<Concert> concerts);
        public Concert Update(Concert concert, Guid id);
        public void Delete(Guid id); 
        public void DeleteRange (IEnumerable<Concert> concerts);
    }
}
