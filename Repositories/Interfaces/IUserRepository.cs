using AplikimiDigjital.Entities;

namespace AplikimiDigjital.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity CreateUser(UserEntity user);
        public void UpdateUser(UserEntity user);
        public void DeleteUser(int id);
        public UserEntity GetUserById(int id);
        public List<UserEntity> GetAllUsers();
    }
}
