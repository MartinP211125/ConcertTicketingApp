
namespace Core.Entities.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public User? Owner { get; set; }
        public virtual ICollection<TicketInShoppingCart>? TicketsInShoppingCart { get; set; }
    }
}
