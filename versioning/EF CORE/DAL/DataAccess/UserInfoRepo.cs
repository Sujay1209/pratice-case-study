using DAL.Models;
using DAL.Models.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class UserInfoRepo : IUserInfoRepo
    {
        private readonly EventDbContext _context;

        public UserInfoRepo(EventDbContext context)
        {
            _context = context;
        }

        public UserInfo RegisterUser(UserInfo user)
        {
            _context.UserInfos.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserInfo UpdateUser(UserInfo user)
        {
            _context.UserInfos.Update(user);
            _context.SaveChanges();
            return user;
        }

        public UserInfo DeleteUser(UserInfo user)
        {
            _context.UserInfos.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public UserInfo ValidateUser(UserInfo user)
        {
            return _context.UserInfos
                .FirstOrDefault(u => u.EmailId == user.EmailId && u.Password == user.Password);
        }

        public UserInfo GetUserById(string emailId)
        {
            return _context.UserInfos.Find(emailId);
        }

        public List<UserInfo> GetAllUsers()
        {
            return _context.UserInfos.ToList();
        }
    }
}
