using DWTTransport.BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Model
{
    public class UserModel
    {

        public UserModel() { }
        public UserModel(tblUser user)
        {
            this.Id = user.Id;
            this.LastName = user.LastName;
            this.FirstName = user.FirstName;
            this.EmailAddress = user.EmailAddress;
            this.Password = user.Password;
            this.UserName = user.UserName;
            this.DateAdded = user.DateAdded;
            this.UserType = user.UserType;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserType { get; set; }
    }
}
