
using Core.DTOs;

namespace Services.Interfaces.Services
{
    public interface IConcertService
    {
        public Task<ICollection<ConcertDTO>> GetAll();
        public ConcertDTO Create(string concertName, string concertImage, double concertRaiting);
        public Task Remove(Guid concertId);
        public Task<ConcertDTO> Update(Guid id, string concertName, string concertImage, double concertRaiting);
    }
}
