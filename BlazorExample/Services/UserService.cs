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
                ["USER_SEX"] = Enum.GetName(typeof(UserSex.userSex), user.UserSex),
                ["IS_ACTIVE"] = user.IsActive
            };

            DbHelper.ExecuteSQL("P_USER_SAVE", dicParam);
        }

        public async Task<IEnumerable<User>> GetAllUsers(Dictionary<string, dynamic> dicParam = null)
        {
            try
            {
                DataTable dtUser = DbHelper.GetDataTable("P_USER_SELECT", dicParam ?? new());
                List<User> users = dtUser.AsEnumerable().Select(x => new User
                {
                    Id = x.Field<long>("ID"),
                    Name = x.Field<string>("NAME"),
                    UserSex = x.Field<UserSex.userSex?>("USER_SEX"),
                    IsActive = x.Field<bool?>("IS_ACTIVE").HasValue ? x.Field<bool>("IS_ACTIVE") : false
                }).ToList();

                return await Task.FromResult(users);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersPage(int curPage)
        {
            return await Task.FromResult(new List<User>());
        }

        public void UpdateUser(long id, User user)
        {
            
        }

        public User FindUser(long id)
        {
            return null;
        }

        public void DeleteUser(long id)
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
