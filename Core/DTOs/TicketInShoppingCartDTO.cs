
namespace Core.DTOs
{
    public class TicketInShoppingCartDTO
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid ShoppingCartId { get; set; }    
        public int Quantity { get; set; }
    }
}
