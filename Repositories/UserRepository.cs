using AplikimiDigjital.Context;
using AplikimiDigjital.Entities;
using AplikimiDigjital.Repositories.Interfaces;

namespace AplikimiDigjital.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly  AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserEntity CreateUser(UserEntity user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public UserEntity GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public List<UserEntity> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void UpdateUser(UserEntity user)
        {
            var oldUser = _dbContext.Users.Find(user.ID);
            _dbContext.Entry(oldUser).CurrentValues.SetValues(user);
            _dbContext.SaveChanges();
        } 
        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
