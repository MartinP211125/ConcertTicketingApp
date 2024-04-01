
using Core.DTOs;

namespace Services.Interfaces.Services
{
    public interface IShoppingCartService
    {
        public Task<ShoppingCartDTO> Get(Guid id);
        public ShoppingCartDTO Create();
    }
}
