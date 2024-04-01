
namespace Core.Entities.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated {  get; set; }
    }
}
