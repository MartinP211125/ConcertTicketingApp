using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase 
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(DTOs.User.UserResponseDTO), StatusCodes.Status200OK)]
        public IActionResult Register([FromBody]DTOs.User.UserDTO userDTO)
        {
            var user = _userService.Register(userDTO.Email, userDTO.Password, userDTO.FirstName, userDTO.LastName);
            var userResponseDTO = new DTOs.User.UserResponseDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return Ok(userResponseDTO);
        }

        [HttpPost]
        [Route("filter")]
        [ProducesResponseType(typeof(DTOs.User.UserResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Filter([FromBody] DTOs.User.UserDTO userDTO)
        {
            var user = await _userService.Get(userDTO.Email, userDTO.Password);
            var userResponseDTO = new DTOs.User.UserResponseDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return Ok(userResponseDTO);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DTOs.User.UserResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var user = await _userService.Get(id);
            var userResponseDTO = new DTOs.User.UserResponseDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return Ok(userResponseDTO);
        }
    }
}
