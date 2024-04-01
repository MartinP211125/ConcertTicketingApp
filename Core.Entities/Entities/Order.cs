
namespace Core.Entities.Entities
{
    public class Order : BaseEntity
    {
        public User? Owner { get; set; }
        public ICollection<TicketInOrder>? TicketsInOrder { get; set; }
    }
}
