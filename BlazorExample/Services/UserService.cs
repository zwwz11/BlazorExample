using BlazorExample.Models;
using Microsoft.JSInterop;

namespace BlazorExample.Services
{
    public class UserService : IUserService
    {
        const int PAGESIZE = 5;
        List<Memo> memos = new();
        List<User> users = new();

        public UserService()
        {
            users = Enumerable.Range(0, 100)
                .Select(x => new User() { 
                    Id = x, Name = $"User{x}", UserSex = UserSex.userSex.Male, IsActive = x % 2 == 0 
                }).ToList();
        }

        public void CreateUser(User user)
        {
            User newUser = new User();
            newUser.Id = user.Id;
            newUser.Name = user.Name;
            newUser.UserSex = user.UserSex;
            newUser.IsActive = true;
            users.Add(newUser);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            await Task.Delay(1000);
            return await Task.FromResult(users.ToList());
        }

        public async Task<IEnumerable<User>> GetAllUsersPage(int curPage)
        {
            try
            {
                return await Task.FromResult(users.GetRange(curPage * PAGESIZE - 5, 5));
            }
            catch
            {
                return null;
            }
        }

        public void UpdateUser(int id, User user)
        {
            User? findUser = users.Find(x => x.Id == id);
            if(findUser != null)
            {
                findUser.Name = user.Name;
            }
        }

        public User FindUser(int id)
        {
            return users.Find(x => x.Id == id);
        }

        public void DeleteUser(int id)
        {
            User? findUser = FindUser(id);
            if(findUser != null)
            {
                users.Remove(findUser);
            }
        }

        public void CreateMemo(Memo memo)
        {
            memos.Add(memo);
        }

        public IEnumerable<Memo> GetAllMemos()
        {
            return memos.ToList();
        }
    }
}
