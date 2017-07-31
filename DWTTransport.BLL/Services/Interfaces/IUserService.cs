using DWTTransport.BLL.Common;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Services.Interfaces
{
    public interface IUserService
    {
        bool ValidateUser(string username, string password);

        DBResult AddUser(UserModel user);

        List<UserModel> GetUsers();
    }
}
