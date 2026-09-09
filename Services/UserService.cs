using Models;
using Repositories;

namespace Services
{
    public class UserService
    {

        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetUsers();
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        // Por que User?
        public User? GetUserById(int id)
        {
            return _userRepository.GetUsers().FirstOrDefault(user => user.Id == id);
        }

    }
}
