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
    public interface IDaybookService
    {

        DaybookModel GetDayBook(int id);
        List<DaybookModel> GetDayBooks(int type);
        List<DaybookModel> GetDayBooks(DateTime dateTimeStamp);
        DBResult SaveDaybook(DaybookModel job);

        List<String> GetAdresses();
    }
}
