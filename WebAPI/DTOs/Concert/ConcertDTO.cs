using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs.Concert
{
    public class ConcertDTO
    {
        [Required]
        public string ConcertName { get; set; }

        [Required]
        public string ConcertImage { get; set; }

        [Required]
        public double ConcertRaiting {  get; set; }
    }
}
