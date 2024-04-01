using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs.Ticket
{
    public class TicketDTO
    {
        [Required]
        public Guid ConcertId { get; set; }
        [Required]
        public string TicketName { get; set; }

        [Required]
        public string TicketDescription { get; set; }

        [Required]
        public string TicketImage {  get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime Date {  get; set; }
    }
}
