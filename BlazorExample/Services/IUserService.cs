using BlazorExample.Models;

namespace BlazorExample.Services
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task UpdateUser(long id, User user);
        Task DeleteUser(long id);
        void CreateMemo(Memo memo);
        Task<User> FindUser(long id);
        
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersPage(int curPage);
        IEnumerable<Memo> GetAllMemos();
    }
}
