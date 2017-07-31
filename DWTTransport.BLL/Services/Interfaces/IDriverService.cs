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
    public interface IDriverService
    {
        List<tblDriver> GetDrivers();

        DriverModel GetDriver(int id);

        List<TruckModel> GetTrucks();
        List<TrailerModel> GetTrailers();
        DBResult SaveDriver(DriverModel model);
    }
}
