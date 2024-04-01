
using Core.Entities.Entities;

namespace Core.Interfaces.Repository
{
    public interface IOrderReposiroty
    {
        public Task<Order> Get(Guid id);
        public Task<Order> GetByUserId(Guid userId);
        public Order Add(Order order);
        public Order Update(Order order, Guid id);
        public void Delete(Guid id);
    }
}
