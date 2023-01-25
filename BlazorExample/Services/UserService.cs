using BlazorExample.Models;
using Microsoft.JSInterop;

namespace BlazorExample.Services
{
    public class UserService : IUserService
    {
        List<User> users = new()
        {
            new User() { Id = 1, Name = "UserA", IsActive = true },
            new User() { Id = 2, Name = "UserB", IsActive = false },
            new User() { Id = 3, Name = "UserC", IsActive = true },
            new User() { Id = 4, Name = "UserD", IsActive = false },
            new User() { Id = 5, Name = "UserE", IsActive = false }
        };
        public void CreateUser(User user)
        {
            User newUser = new User();
            newUser.Id = user.Id;
            newUser.Name = user.Name;
            newUser.UserSex = user.UserSex;
            newUser.IsActive = true;
            users.Add(newUser);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
