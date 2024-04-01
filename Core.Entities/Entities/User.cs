
namespace Core.Entities.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Order? Order { get; set; }
        public Guid OrderId { get; set; }
        public virtual ShoppingCart? ShoppingCart { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
