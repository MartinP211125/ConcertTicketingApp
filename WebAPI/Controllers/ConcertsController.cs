using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services;

namespace WebAPI.Controllers
{
    [Route("api/concerts")]
    [ApiController]
    public class ConcertsController : ControllerBase
    {
        private readonly IConcertService _concertService;
        public ConcertsController(IConcertService concertService)
        {
            _concertService = concertService;
        }

        /// <summary>
        /// Get all concerts
        /// </summary>
        /// <returns>Returns a list of all available concerts</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<ConcertDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllConcerts()
        {
            var concerts = await _concertService.GetAll();
            return Ok(concerts);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ConcertDTO), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] DTOs.Concert.ConcertDTO concertDTO)
        {
            var concert = _concertService.Create(concertDTO.ConcertName, concertDTO.ConcertImage, concertDTO.ConcertRaiting);
            return Ok(concert);
        }

        [HttpPut]
        [Route("{concertId}")]
        [ProducesResponseType(typeof(ConcertDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute]Guid concertId, [FromBody] DTOs.Concert.ConcertDTO concertDTO)
        {
            var concert = await _concertService.Update(concertId, concertDTO.ConcertName, concertDTO.ConcertImage, concertDTO.ConcertRaiting);
            return Ok(concert);
        }

        [HttpDelete]
        [Route("{concertId}")]
        public async Task<IActionResult> Delete([FromRoute]Guid concertId)
        {
            await _concertService.Remove(concertId);
            return Ok();
        }
    }
}
