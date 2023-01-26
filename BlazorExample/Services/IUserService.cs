using BlazorExample.Models;

namespace BlazorExample.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
        User FindUser(int id);
        
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetAllUsersPage(int curPage);
    }
}
