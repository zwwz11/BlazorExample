using BlazorExample.Common;
using BlazorExample.Models;
using Microsoft.JSInterop;
using System.Data;

namespace BlazorExample.Services
{
    public class UserService : IUserService
    {
        const int PAGESIZE = 5;

        public void CreateUser(User user)
        {
            var dicParam = new Dictionary<string, dynamic>()
            {
                ["NAME"] = user.Name,
                ["USER_SEX"] = user.UserSex,
                ["IS_ACTIVE"] = user.IsActive
            };

            DbHelper.ExecuteSQL("P_USER_SAVE", dicParam);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            List<User> users = new();
            DataTable dtUser = DbHelper.GetDataTable("P_USER_SELECT", new Dictionary<string, dynamic>());
            foreach (DataRow dr in dtUser.Rows)
            {
                User user = new User()
                {
                    Id = int.Parse(dr["ID"].ToString()),
                    Name = dr["NAME"].ToString(),
                    UserSex = (UserSex.userSex)Enum.Parse(typeof(UserSex.userSex), dr["USER_SEX"].ToString()),
                    IsActive = bool.Parse(dr["IS_ACTIVE"].ToString())
                };
                users.Add(user);
            }

            return users;
        }

        public async Task<IEnumerable<User>> GetAllUsersPage(int curPage)
        {
            return null;
        }

        public void UpdateUser(int id, User user)
        {
            
        }

        public User FindUser(int id)
        {
            return null;
        }

        public void DeleteUser(int id)
        {
            
        }

        public void CreateMemo(Memo memo)
        {
            
        }

        public IEnumerable<Memo> GetAllMemos()
        {
            return null;
        }
    }
}
