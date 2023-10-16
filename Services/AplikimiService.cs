using AplikimiDigjital.Entities;
using AplikimiDigjital.Models;
using AplikimiDigjital.Repositories.Interfaces;
using AplikimiDigjital.Services.Interfaces;
using AutoMapper;

namespace AplikimiDigjital.Services
{
    public class AplikimiService : IAplikimiService
    {
        private readonly IAplikimiRepository _aplikimiRepository;
        private readonly IMapper _mapper;

        public AplikimiService(IAplikimiRepository aplikimiRepository,IMapper mapper)
        {
            _aplikimiRepository = aplikimiRepository;
            _mapper = mapper;
        }

        public Aplikimi CreateAplikimi(Aplikimi aplikimi)
        {
            
                var aplikimiEntity = _mapper.Map<AplikimiEntity>(aplikimi);
                var result = _aplikimiRepository.CreateAplikimi(aplikimiEntity);
                var aplikimiCreated = _mapper.Map<Aplikimi>(aplikimi);
                return aplikimiCreated;
            
        }

        public void DeleteAplikim(int id)
        {
            _aplikimiRepository.DeleteAplikimi(id);
        }

        public List<Aplikimi> GetAllAplikim()
        {
            var aplikimetEntity = _aplikimiRepository.GetAllAplikimet();
            var aplikimet = _mapper.Map<List<Aplikimi>>(aplikimetEntity);
            return aplikimet;
        }

        public Aplikimi GetAplikimiById(int id)
        {
            var aplikimiEntity = _aplikimiRepository.GetAplikimiById(id);
            var aplikimi = _mapper.Map<Aplikimi>(aplikimiEntity);
            return aplikimi;
        }

        public Aplikimi GetAplikimiByName(string name)
        {
            var aplikimiEntity = _aplikimiRepository.GetAplikimiByName(name);
            var aplikimi = _mapper.Map<Aplikimi>(aplikimiEntity);
            return aplikimi;
        }

        public void UpdateAplikimi(Aplikimi aplikimi)
        {
            try
            {
                var aplikimiEntity = _mapper.Map<AplikimiEntity>(aplikimi);
                _aplikimiRepository.UpdateAplikimi(aplikimiEntity);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
