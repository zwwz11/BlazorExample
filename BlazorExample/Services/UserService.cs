using BlazorExample.Common;
using BlazorExample.Models;
using Microsoft.JSInterop;
using System.Data;

namespace BlazorExample.Services
{
    public class UserService : IUserService
    {
        const int PAGESIZE = 5;

        public async Task CreateUser(User user)
        {
            try
            {
                var dicParam = new Dictionary<string, dynamic>()
                {
                    ["MODE"] = 1,
                    ["NAME"] = user.Name,
                    ["USER_SEX"] = Enum.GetName(typeof(UserSex.userSex), user.UserSex),
                    ["IS_ACTIVE"] = user.IsActive
                };

                await Task.Run(() =>
                {
                    DbHelper.ExecuteSQL("P_USER_SAVE", dicParam);
                });
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                List<User> users = new List<User>();
                var dicParam = new Dictionary<string, dynamic>()
                {
                    ["MODE"] = 1
                };

                await Task.Run(() =>
                {
                    DataTable dtUser = DbHelper.GetDataTable("P_USER_SELECT", dicParam);
                    users = dtUser.AsEnumerable().Select(x => new User
                    {
                        Id = x.Field<long>("ID"),
                        Name = x.Field<string>("NAME"),
                        UserSex = Enum.Parse<UserSex.userSex>(x.Field<string>("USER_SEX")),
                        IsActive = x.Field<bool?>("IS_ACTIVE").HasValue ? x.Field<bool>("IS_ACTIVE") : false
                    }).ToList();
                });

                return users;
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

        public async Task UpdateUser(long id, User user)
        {
            try
            {
                var dicParam = new Dictionary<string, dynamic>()
                {
                    ["MODE"] = 2,
                    ["ID"] = id,
                    ["NAME"] = user.Name,
                    ["USER_SEX"] = user.UserSex,
                    ["IS_ACTIVE"] = user.IsActive
                };

                await Task.Run(() =>
                {
                    DbHelper.ExecuteSQL("P_USER_SAVE", dicParam);
                });
            }
            catch
            {
                throw;
            }

        }

        public async Task<User> FindUser(long id)
        {
            try
            {
                var dicParam = new Dictionary<string, dynamic>()
                {
                    ["MODE"] = 2,
                    ["ID"] = id,
                };

                DataRow rowUser = null;
                await Task.Run(() =>
                {
                    rowUser = DbHelper.GetDataTable("P_USER_SELECT", dicParam).AsEnumerable().FirstOrDefault();
                });

                User findUser = new User()
                {
                    Id = rowUser.Field<long>("ID"),
                    Name = rowUser.Field<string>("NAME"),
                    UserSex = Enum.Parse<UserSex.userSex>(rowUser.Field<string>("USER_SEX")),
                    IsActive = rowUser.Field<bool>("IS_ACTIVE")
                };

                return findUser;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteUser(long id)
        {
            try
            {
                var dicParam = new Dictionary<string, dynamic>()
                {
                    ["MODE"] = 3,
                    ["ID"] = id,
                };

                await Task.Run(() =>
                {
                    DbHelper.ExecuteSQL("P_USER_SAVE", dicParam);
                });
            }
            catch
            {
                throw;
            }
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
