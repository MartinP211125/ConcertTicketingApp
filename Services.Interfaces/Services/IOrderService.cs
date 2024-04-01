
using Core.DTOs;

namespace Services.Interfaces.Services
{
    public interface IOrderService
    {
        public Task<OrderDTO> Get(Guid id);
        public OrderDTO Create();
    }
}
