using DAL.Models;
using DAL.Models.DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public class UserInfoBL
    {
        private readonly IUserInfoRepo _repo;

        // Constructor injection of the repository
        public UserInfoBL(IUserInfoRepo repo)
        {
            _repo = repo;
        }

        // Add/Register new user
        public UserInfo RegisterUser(UserInfo user)
        {
            return _repo.RegisterUser(user);
        }

        // Update existing user
        public UserInfo UpdateUser(UserInfo user)
        {
            return _repo.UpdateUser(user);
        }

        // Delete user by entity
        public UserInfo DeleteUser(UserInfo user)
        {
            return _repo.DeleteUser(user);
        }

        // Delete user by email (helper method)
        public void DeleteUser(string emailId)
        {
            var user = _repo.GetUserById(emailId);
            if (user != null)
            {
                _repo.DeleteUser(user);
            }
        }

        // Validate login
        public UserInfo ValidateUser(UserInfo user)
        {
            return _repo.ValidateUser(user);
        }

        // Get user by Email ID
        public UserInfo GetUserById(string emailId)
        {
            return _repo.GetUserById(emailId);
        }

        // Get all users
        public List<UserInfo> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
    }
}
