using BlazorExample.Models;

namespace BlazorExample.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        User UpdateUser(User user);
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetAllUsersPage(int curPage);
    }
}
