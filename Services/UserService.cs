using AplikimiDigjital.Entities;
using AplikimiDigjital.Models;
using AplikimiDigjital.Repositories.Interfaces;
using AplikimiDigjital.Services.Interfaces;
using AutoMapper;

namespace AplikimiDigjital.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public User CreateUser(User user)
        {
            try
            {
                var userEntity = _mapper.Map<UserEntity>(user);
                var result = _userRepository.CreateUser(userEntity);
                var userCreated = _mapper.Map<User>(user);
                return userCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            var userEntities = _userRepository.GetAllUsers();
            var users = _mapper.Map<List<User>>(userEntities);
            return users;
        }

        public User GetUserById(int id)
        {
            var userEntity = _userRepository.GetUserById(id);
            var user = _mapper.Map<User>(userEntity);
            return user;
        }

        public void UpdateUser(User user)
        {
            var existingUser = _userRepository.GetUserById(user.ID);
            var userEntity = _mapper.Map<UserEntity>(user);
            _userRepository.UpdateUser(userEntity);
        }
    }
}
