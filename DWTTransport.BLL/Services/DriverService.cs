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
    public class DriverService : IDriverService
    {
        private DWTEntities db;
        
        public DriverService()
        {
            db = new DWTEntities();
        }

        public DriverModel GetDriver(int id)
        {
            var driver = db.tblDrivers.FirstOrDefault(d=> d.DriverID == id);
            return new DriverModel { Name = driver.Name, Surname = driver.Surname, Id = driver.DriverID };
        }

        public List<tblDriver> GetDrivers()
        {
            return db.tblDrivers.ToList();
        }

        public List<TrailerModel> GetTrailers()
        {
            var retval = new List<TrailerModel>();
            var trailers = db.tblTrailers.ToList();
            trailers.ForEach(t => retval.Add(new TrailerModel(t)));
            return retval;
        }

        public List<TruckModel> GetTrucks()
        {
            var retval = new List<TruckModel>();
            var trucks = db.tblTrucks.ToList();
            trucks.ForEach(t => retval.Add(new TruckModel(t)));
            return retval;
        }

        public DBResult SaveDriver(DriverModel model)
        {
            tblDriver driver = model.Id == 0 ? new tblDriver() : db.tblDrivers.FirstOrDefault(d => d.DriverID == model.Id);
            driver.Name = model.Name;
            driver.Surname = model.Surname;
            try
            {
                if (model.Id == 0)
                {
                    db.tblDrivers.Add(driver);
                }
                db.SaveChanges();
                return new DBResult { ReturnCode = ReturnCode.Success };
            }
            catch(Exception ex)
            {
                return new DBResult { Message = ex.Message, ReturnCode = ReturnCode.Failed };
            }
        }
    }
}
