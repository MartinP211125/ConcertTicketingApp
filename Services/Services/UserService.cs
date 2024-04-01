
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Services.Interfaces.Services;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        public async Task<UserDTO> Get(string email, string password)
        {
           var user = (await _userRepository.Find(x => x.Email == email && x.Password == password)).FirstOrDefault();  
           var userDTO = _mapper.Map<UserDTO>(user);
           return userDTO;
        }

        public async Task<UserDTO> Get(Guid id)
        {
            var user = (await _userRepository.Find(x => x.Id == id)).FirstOrDefault();
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public UserDTO Register(string email, string password, string firstName, string lastName)
        {
            var shoppingCartDTO =  _shoppingCartService.Create();
            var orderDTO = _orderService.Create();
            var userDTO = new UserDTO {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                ShoppingCartId = shoppingCartDTO.Id,
                OrderId = orderDTO.Id
            };
            var user = _mapper.Map<User>(userDTO);

            return _mapper.Map<UserDTO>(_userRepository.Add(user));
        }
    }
}
