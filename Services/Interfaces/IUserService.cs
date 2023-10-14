using AplikimiDigjital.Models;

namespace AplikimiDigjital.Services.Interfaces
{
    public interface IUserService
    {
        public User CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int id);
        public User GetUserById(int id);
        public List<User> GetAllUsers();
    }
}
