using DAL.Models;
using DAL.Models.DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface IUserInfoRepo
    {
        UserInfo RegisterUser(UserInfo user);
        UserInfo UpdateUser(UserInfo user);
        UserInfo DeleteUser(UserInfo user);
        UserInfo ValidateUser(UserInfo user);
        UserInfo GetUserById(string emailId);
        List<UserInfo> GetAllUsers();
    }
}

