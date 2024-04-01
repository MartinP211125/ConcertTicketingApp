
using Core.DTOs;

namespace Services.Interfaces.Services
{
    public interface IUserService
    {
        public UserDTO Register(string email, string password, string firstName, string lastName);
        public Task<UserDTO> Get(string email, string password);
        public Task<UserDTO> Get(Guid id);
    }
}
