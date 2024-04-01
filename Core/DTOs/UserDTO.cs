
namespace Core.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid OrderId { get; set; }
    }
}
