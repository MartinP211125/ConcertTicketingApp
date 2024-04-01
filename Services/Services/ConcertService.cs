
using Ardalis.GuardClauses;
using AutoMapper;
using Core.DTOs;
using Core.Entities.Entities;
using Core.Interfaces.Repository;
using Services.Interfaces.Services;

namespace Services.Services
{
    public class ConcertService : IConcertService
    {

        private readonly IConcertRepository _concertRepository;
        private readonly IMapper _mapper;
        public ConcertService(IConcertRepository concertRepository, IMapper mapper)
        {
            _concertRepository = concertRepository;
            _mapper = mapper;
        }

        public ConcertDTO Create(string concertName, string concertImage, double concertRaiting)
        {
            var concertDTO = new ConcertDTO
            {
                Id = Guid.NewGuid(),
                ConcertImage = concertImage,
                ConcertName = concertName,
                ConcertRaiting = concertRaiting
            };

            var concert = _mapper.Map<Concert>(concertDTO);

            return _mapper.Map<ConcertDTO>(_concertRepository.Add(concert));
        }

        public async Task<ICollection<ConcertDTO>> GetAll()
        {
            var concert = await _concertRepository.GetAll();
            return _mapper.Map<ICollection<ConcertDTO>>(concert);
        }

        public async Task Remove(Guid concertId)
        {
            var concert = (await _concertRepository.Find(x => x.Id == concertId)).FirstOrDefault();
            Guard.Against.Null(concert, nameof(concert));

            _concertRepository.Delete(concert.Id);
        }

        public async Task<ConcertDTO> Update(Guid id, string concertName, string concertImage, double concertRaiting)
        {
           var concert = (await _concertRepository.Find(x => x.Id == id)).FirstOrDefault();
           Guard.Against.Null(concert, nameof (concert));
           
           concert.ConcertName = concertName;
           concert.ConcertImage = concertImage;
           concert.ConcertRaiting = concertRaiting;
           
           return _mapper.Map<ConcertDTO>(_concertRepository.Update(concert, id));
        }
    }
}
