using Core.DTOs;
using Core.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ITicketInOrderService _ticketInOrderService;
        public OrdersController(ITicketInOrderService ticketInOrderService)
        {
            _ticketInOrderService = ticketInOrderService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<DTOs.Ticket.TicketResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create()
        {
            var userId = GetUserIdFromAuthorizationHeader();
            var ticketsInOrder = await _ticketInOrderService.Create(userId);
            var ticketsInOrderDTO = ticketsInOrder.Select(x => new DTOs.Ticket.TicketResponseDTO()
            {
                TicketId = x.TicketId,
                Quantity = x.Quantity
            });

            return Ok(ticketsInOrderDTO);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DTOs.Ticket.TicketResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var userId = GetUserIdFromAuthorizationHeader();
            var ticketsInOrder = await _ticketInOrderService.GetAll(userId);

            var ticketsInOrderDTO = ticketsInOrder.Select(x => new DTOs.Ticket.TicketResponseDTO()
            {
                TicketId = x.TicketId,
                Quantity = x.Quantity
            });
            return Ok(ticketsInOrderDTO);
        }
        private Guid GetUserIdFromAuthorizationHeader()
        {
            var authorisationJWTHeader = Request.Headers["Authorization"].FirstOrDefault();
            var token = AccessTokenHelper.GetAccessToken(authorisationJWTHeader);
            var userId = AccessTokenHelper.GetUserId(token);
            return userId;
        }
    }
}
