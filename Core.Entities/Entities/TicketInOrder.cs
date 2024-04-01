
namespace Core.Entities.Entities
{
    public class TicketInOrder : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Guid OrderId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual Order? Order { get; set; }
        public int Quantity { get; set; }
    }
}
