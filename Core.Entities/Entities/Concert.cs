
namespace Core.Entities.Entities
{
    public class Concert : BaseEntity
    {
        public string ConcertName { get; set; }
        public string ConcertImage { get; set; }
        public double ConcertRaiting { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}
