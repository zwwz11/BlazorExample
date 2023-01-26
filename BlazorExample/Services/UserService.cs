using BlazorExample.Models;
using Microsoft.JSInterop;

namespace BlazorExample.Services
{
    public class UserService : IUserService
    {
        const int PAGESIZE = 5;
        List<User> users = new()
        {
            new User() { Id = 1, Name = "UserA", IsActive = true },
            new User() { Id = 2, Name = "UserB", IsActive = false },
            new User() { Id = 3, Name = "UserC", IsActive = true },
            new User() { Id = 4, Name = "UserD", IsActive = false },
            new User() { Id = 5, Name = "UserE", IsActive = false },
            new User() { Id = 6, Name = "UserA", IsActive = true },
            new User() { Id = 7, Name = "UserB", IsActive = false },
            new User() { Id = 8, Name = "UserC", IsActive = true },
            new User() { Id = 9, Name = "UserD", IsActive = false },
            new User() { Id = 10, Name = "UserE", IsActive = false },
            new User() { Id = 11, Name = "UserG", IsActive = true },
            new User() { Id = 12, Name = "UserH", IsActive = false },
            new User() { Id = 13, Name = "UserI", IsActive = true },
            new User() { Id = 14, Name = "UserJ", IsActive = false },
            new User() { Id = 15, Name = "UserK", IsActive = false },
            new User() { Id = 16, Name = "UserL", IsActive = true },
            new User() { Id = 17, Name = "UserM", IsActive = false },
            new User() { Id = 18, Name = "UserN", IsActive = true },
            new User() { Id = 19, Name = "UserO", IsActive = false },
            new User() { Id = 20, Name = "UserP", IsActive = false },
            new User() { Id = 21, Name = "UserQ", IsActive = true },
            new User() { Id = 22, Name = "UserR", IsActive = false },
            new User() { Id = 23, Name = "UserS", IsActive = true },
            new User() { Id = 24, Name = "UserT", IsActive = false },
            new User() { Id = 25, Name = "UserU", IsActive = false },
            new User() { Id = 26, Name = "User26", IsActive = true },
            new User() { Id = 27, Name = "User27", IsActive = false },
            new User() { Id = 28, Name = "User28", IsActive = false }
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

        public IEnumerable<User> GetAllUsersPage(int curPage)
        {
            try
            {
                return users.GetRange(curPage * PAGESIZE - 5, 5);
            }
            catch
            {
                return null;
            }
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
