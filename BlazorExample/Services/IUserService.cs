using BlazorExample.Models;

namespace BlazorExample.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        void UpdateUser(long id, User user);
        void DeleteUser(long id);
        void CreateMemo(Memo memo);
        User FindUser(long id);
        
        Task<IEnumerable<User>> GetAllUsers(Dictionary<string, dynamic> dicParam = null);
        Task<IEnumerable<User>> GetAllUsersPage(int curPage);
        IEnumerable<Memo> GetAllMemos();
    }
}
