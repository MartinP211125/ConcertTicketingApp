
using Core.DTOs;

namespace Services.Interfaces.Services
{
    public interface ITicketService
    {
        public TicketDTO Create(Guid concertId, string ticketName,  string ticketDescription, string ticketImage, int price, DateTime date);
        public Task Remove(Guid id);
        public Task<TicketDTO> Get(Guid id);
        public Task<ICollection<TicketDTO>> GetAll();
        public Task<ICollection<TicketDTO>> GetAll(DateTime date);
        public Task<ICollection<TicketDTO>> GetByConcertId(Guid concertId);
        public Task<TicketDTO> Update(Guid id, string ticketName, string ticketDescription, string ticketImage, int price, DateTime date);
        
    }
}
