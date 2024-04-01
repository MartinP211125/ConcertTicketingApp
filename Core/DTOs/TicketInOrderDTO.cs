
namespace Core.DTOs
{
    public class TicketInOrderDTO
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
