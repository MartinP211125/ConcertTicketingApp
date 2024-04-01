using Core.Entities.Entities;

namespace Core.Interfaces.Repository
{
    public interface IShoppingCartRepository
    {
        public Task<ShoppingCart> Get(Guid id);
        public Task<ShoppingCart> GetByUserId(Guid userId);
        public ShoppingCart Add(ShoppingCart shoppingCart);
        public ShoppingCart Update(ShoppingCart shoppingCart, Guid id);
        public void Delete(Guid id);
    }
}
