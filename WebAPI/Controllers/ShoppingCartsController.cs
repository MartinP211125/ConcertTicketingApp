using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/shopping-cart")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly ITicketInShoppingCartService _ticketInShoppingCartService;
        public ShoppingCartsController(ITicketInShoppingCartService ticketInShoppingCartService)
        {
            _ticketInShoppingCartService = ticketInShoppingCartService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(DTOs.Ticket.TicketResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] DTOs.Ticket.TicketResponseDTO ticketInShoppingCartDTO)
        {
            var userId = GetUserIdFromAuthorizationHeader();

            var ticketInShoppingCart = await _ticketInShoppingCartService.Create(ticketInShoppingCartDTO.TicketId, userId, ticketInShoppingCartDTO.Quantity);
            var ticketInShoppingCartResponseDTO = new DTOs.Ticket.TicketResponseDTO
            {
                TicketId = ticketInShoppingCart.TicketId,
                Quantity = ticketInShoppingCart.Quantity
            };
            return Ok(ticketInShoppingCartResponseDTO);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DTOs.Ticket.TicketResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserIdFromAuthorizationHeader();

            var ticketsInShoppingCart = await _ticketInShoppingCartService.GetAll(userId);
            var ticketsInShoppingCartResponse = ticketsInShoppingCart.Select(x => new DTOs.Ticket.TicketResponseDTO()
            {
                TicketId = x.TicketId,
                Quantity = x.Quantity
            });
            return Ok(ticketsInShoppingCartResponse);
        }

        [HttpDelete]
        [Route("{ticketId}")]
        public async Task<IActionResult> Remove([FromRoute]Guid ticketId)
        {
            var userId = GetUserIdFromAuthorizationHeader();
            await _ticketInShoppingCartService.Remove(ticketId, userId);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(DTOs.Ticket.TicketResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] DTOs.Ticket.TicketResponseDTO ticketInShoppingCartDTO)
        {
            var userId = GetUserIdFromAuthorizationHeader();

            var ticketInShoppingCart = await _ticketInShoppingCartService.Update(ticketInShoppingCartDTO.TicketId, userId, ticketInShoppingCartDTO.Quantity);
            var ticketInShoppingCartResponseDTO = new DTOs.Ticket.TicketResponseDTO
            {
                TicketId = ticketInShoppingCart.TicketId,
                Quantity = ticketInShoppingCart.Quantity
            };
            return Ok(ticketInShoppingCartResponseDTO);
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
