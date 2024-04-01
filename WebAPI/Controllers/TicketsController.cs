using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services;

namespace WebAPI.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TicketDTO), StatusCodes.Status200OK)]  
        public IActionResult Create([FromBody]DTOs.Ticket.TicketDTO ticketDTO)
        {
            var ticket = _ticketService.Create(ticketDTO.ConcertId, ticketDTO.TicketName, ticketDTO.TicketDescription, ticketDTO.TicketImage, ticketDTO.Price, ticketDTO.Date);
            return Ok(ticket);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<TicketDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var tickets = await _ticketService.GetAll();
            return Ok(tickets);
        }

        [HttpGet]
        [ProducesResponseType(typeof(TicketDTO), StatusCodes.Status200OK)]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var ticket = await _ticketService.Get(id);
            return Ok(ticket);
        }

        [HttpGet]
        [Route("concert/{concertId}")]
        [ProducesResponseType(typeof(ICollection<TicketDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByConcertId([FromRoute]Guid concertId)
        {
            var tickets = await _ticketService.GetByConcertId(concertId);
            return Ok(tickets);
        }

        [HttpPost]
        [Route("filter")]
        [ProducesResponseType(typeof(ICollection<TicketDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Filter([FromBody]DateTime date)
        {
            var ticket = await _ticketService.GetAll(date);
            return Ok(ticket);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(TicketDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]TicketDTO ticketDTO)
        {
            var ticket = await _ticketService.Update(id, ticketDTO.TicketName, ticketDTO.TicketDescription, ticketDTO.TicketImage, ticketDTO.Price, ticketDTO.Date);
            return Ok(ticket);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            await _ticketService.Remove(id);
            return Ok();
        }
    }
}
