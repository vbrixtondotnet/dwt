using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWTTransport.BLL.Common;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Model;
using DWTTransport.BLL.Services.Interfaces;

namespace DWTTransport.BLL.Services
{
    public class UserService : IUserService
    {
        private DWTEntities db;
        
        public UserService()
        {
            db = new DWTEntities();
        }

        public DBResult AddUser(UserModel user)
        {
            var retval = new DBResult { ReturnCode = ReturnCode.Success };
            var tblUser = user.Id == 0 ? new tblUser() : db.tblUsers.FirstOrDefault(u => u.Id == user.Id);

            tblUser.FirstName = user.FirstName;
            tblUser.LastName = user.LastName;
            tblUser.UserName = user.UserName;
            tblUser.Password = user.Password;
            tblUser.UserType = user.UserType;
            tblUser.EmailAddress = user.EmailAddress;

            if (user.Id == 0)
            {
                tblUser.DateAdded = DateTime.Now;
                db.tblUsers.Add(tblUser);
            }
            db.SaveChanges();
            return retval;
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> retval = new List<UserModel>();
            var dbUsers = db.tblUsers.ToList();
            foreach(var dbUser in dbUsers)
            {
                retval.Add(new UserModel(dbUser));
            }
            return retval;
        }

        public bool ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
