
namespace Core.Entities.Entities
{
    public class Ticket : BaseEntity
    {
        public Guid ConcertId { get; set; }
        public Concert Concert { get; set; }
        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }
        public string? TicketImage { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public virtual ICollection<TicketInShoppingCart>? TicketsInShoppingCart { get; set; }
        public virtual ICollection<TicketInOrder>? TicketsInOrder { get; set; }
    }
}
