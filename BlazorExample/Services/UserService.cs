using BlazorExample.Models;

namespace BlazorExample.Services
{
    public class UserService : IUserService
    {
        List<User> users = new()
        {
            new User() { Id = 1, Name = "UserA" },
            new User() { Id = 2, Name = "UserB" },
            new User() { Id = 3, Name = "UserC" },
            new User() { Id = 4, Name = "UserD" },
            new User() { Id = 5, Name = "UserE" }
        };
        public void CreateUser(User user)
        {
            User newUser = new User();
            newUser.Id = user.Id;
            newUser.Name = user.Name;
            users.Add(newUser);
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
