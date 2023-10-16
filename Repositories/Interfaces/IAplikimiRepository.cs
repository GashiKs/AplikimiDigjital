using AplikimiDigjital.Entities;

namespace AplikimiDigjital.Repositories.Interfaces
{
    public interface IAplikimiRepository
    {
        public AplikimiEntity CreateAplikimi(AplikimiEntity aplikimi);
        public void UpdateAplikimi(AplikimiEntity aplikimi);
        public void DeleteAplikimi(int id);
        public AplikimiEntity GetAplikimiById(int id);
        public List<AplikimiEntity> GetAllAplikimet();
        public AplikimiEntity GetAplikimiByName(string name);
    }
}
