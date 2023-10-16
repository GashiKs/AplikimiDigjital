using AplikimiDigjital.Models;

namespace AplikimiDigjital.Services.Interfaces
{
    public interface IAplikimiService
    {
        public Aplikimi CreateAplikimi(Aplikimi aplikimi);
        public void UpdateAplikimi(Aplikimi aplikimi);
        public void DeleteAplikim(int id);
        public Aplikimi GetAplikimiById(int id);
        public List<Aplikimi> GetAllAplikim();
        public Aplikimi GetAplikimiByName(string name);
    }
}
