 
namespace Core.DTOs
{
    public class TicketDTO
    {
        public Guid Id { get; set; }
        public Guid ConcertId { get; set; }
        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }
        public string? TicketImage { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}
