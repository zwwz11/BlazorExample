using BlazorExample.Models;
using Microsoft.JSInterop;

namespace BlazorExample.Services
{
    public class UserService : IUserService
    {
        const int PAGESIZE = 5;
        List<Memo> memos = new();
        List<User> users = new()
        {
            new User() { Id = 1, Name = "User1", IsActive = true },
            new User() { Id = 2, Name = "User2", IsActive = false },
            new User() { Id = 3, Name = "User3", IsActive = true },
            new User() { Id = 4, Name = "User4", IsActive = false },
            new User() { Id = 5, Name = "User5", IsActive = false },
            new User() { Id = 6, Name = "User6", IsActive = true },
            new User() { Id = 7, Name = "User7", IsActive = false },
            new User() { Id = 8, Name = "User8", IsActive = true },
            new User() { Id = 9, Name = "User9", IsActive = false },
            new User() { Id = 10, Name = "User10", IsActive = false },
            new User() { Id = 11, Name = "User11", IsActive = true },
            new User() { Id = 12, Name = "User12", IsActive = false },
            new User() { Id = 13, Name = "User13", IsActive = true },
            new User() { Id = 14, Name = "User14", IsActive = false },
            new User() { Id = 15, Name = "User15", IsActive = false },
            new User() { Id = 16, Name = "User16", IsActive = true },
            new User() { Id = 17, Name = "User17", IsActive = false },
            new User() { Id = 18, Name = "User18", IsActive = true },
            new User() { Id = 19, Name = "User19", IsActive = false },
            new User() { Id = 20, Name = "User20", IsActive = false },
            new User() { Id = 21, Name = "User21", IsActive = true },
            new User() { Id = 22, Name = "User22", IsActive = false },
            new User() { Id = 23, Name = "User23", IsActive = true },
            new User() { Id = 24, Name = "User24", IsActive = false },
            new User() { Id = 25, Name = "User25", IsActive = false },
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
