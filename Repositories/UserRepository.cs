using Models;

namespace Repositories
{
    public class UserRepository
    {
        // Class de exemplo,
        // No projeto real, os dados virao de uma base de dados
        List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Link",
                Password = "Pizza10",
                IsAdmin = true
            },

            new User
            {
                Id = 2,
                Name = "Zelda",
                Password = "3force",
                IsAdmin = false
            }
        };

        public List<User> GetUsers()
        {
            return users;
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

    }
}
