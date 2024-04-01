
using Ardalis.GuardClauses;
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Services.Interfaces.Services;

namespace Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public TicketDTO Create(Guid concertId, string ticketName, string ticketDescription, string ticketImage, int price, DateTime date)
        {
            var ticketDTO = new TicketDTO
            {
                Id = Guid.NewGuid(),
                ConcertId = concertId,
                TicketName = ticketName,
                TicketDescription = ticketDescription,
                TicketImage = ticketImage,
                Price = price,
                Date = date
            };

            var ticket = _mapper.Map<Ticket>(ticketDTO);

            return _mapper.Map<TicketDTO>(_ticketRepository.Add(ticket));
        }

        public async Task<TicketDTO> Get(Guid id)
        {
            var ticket = await _ticketRepository.Get(id);
            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task<ICollection<TicketDTO>> GetAll()
        {
            var tickets = await _ticketRepository.GetAll();
            return _mapper.Map<ICollection<TicketDTO>>(tickets);
        }

        public async Task<ICollection<TicketDTO>> GetAll(DateTime date)
        {
            var tickets = await _ticketRepository.Find(x => x.Date.Date == date.Date);
            return _mapper.Map<ICollection<TicketDTO>>(tickets);
        }

        public async Task<ICollection<TicketDTO>> GetByConcertId(Guid concertId)
        {
            var tickets = await _ticketRepository.Find(x => x.ConcertId == concertId);
            return _mapper.Map<ICollection<TicketDTO>>(tickets);
        }

        public async Task Remove(Guid id)
        {
            var ticket = await _ticketRepository.Get(id);
            Guard.Against.Null(ticket, nameof(ticket));

            _ticketRepository.Delete(ticket.Id);
        }

        public async Task<TicketDTO> Update(Guid id, string ticketName, string ticketDescription, string ticketImage, int price, DateTime date)
        {
            var ticket = await _ticketRepository.Get(id);
            Guard.Against.Null(ticket, nameof(ticket));

            ticket.TicketName = ticketName;
            ticket.TicketDescription = ticketDescription;
            ticket.TicketImage = ticketImage;
            ticket.Price = price;
            ticket.Date = date;

            return _mapper.Map<TicketDTO>(_ticketRepository.Update(ticket, id));
        }
    }
}
