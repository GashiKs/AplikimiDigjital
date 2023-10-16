using AplikimiDigjital.Context;
using AplikimiDigjital.Entities;
using AplikimiDigjital.Repositories.Interfaces;

namespace AplikimiDigjital.Repositories
{
    public class AplikimiRepository : IAplikimiRepository
    {
        private readonly AppDbContext _dbContext;
        public AplikimiRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AplikimiEntity CreateAplikimi(AplikimiEntity aplikimi)
        {
            _dbContext.Aplikimet.Add(aplikimi);
            _dbContext.SaveChanges();
            return aplikimi;
        }

        public void DeleteAplikimi(int id)
        {
            var aplikimi = _dbContext.Aplikimet.Find(id);
            _dbContext.Aplikimet.Remove(aplikimi);
            _dbContext.SaveChanges();
        }

        public List<AplikimiEntity> GetAllAplikimet()
        {
            return _dbContext.Aplikimet.ToList(); 
        }

        public AplikimiEntity GetAplikimiById(int id)
        {
            return _dbContext.Aplikimet.Find(id);
        }

        public void UpdateAplikimi(AplikimiEntity aplikimi)
        {
            var oldAplikimi = _dbContext.Aplikimet.Find(aplikimi.ID);
            _dbContext.Aplikimet.Entry(oldAplikimi).CurrentValues.SetValues(aplikimi);
            _dbContext.SaveChanges();
        }
    }
}
