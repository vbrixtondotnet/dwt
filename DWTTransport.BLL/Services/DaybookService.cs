using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWTTransport.BLL.Common;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Services.Interfaces;
using DWTTransport.BLL.Model;

namespace DWTTransport.BLL.Services
{
    public class DaybookService : IDaybookService
    {
        private DWTEntities db;
        
        public DaybookService()
        {
            db = new DWTEntities();
        }

        public List<string> GetAdresses()
        {
            return db.tblJobs.Select(p => p.Address).Distinct().ToList();
        }

        public DaybookModel GetDayBook(int id)
        {
            var job = db.tblJobs.FirstOrDefault(j => j.JobID == id);
            return new DaybookModel(job);

        }
        

        public List<DaybookModel> GetDayBooks(int type)
        {
            List<DaybookModel> dbooks = new List<DaybookModel>();
            
            var tblJobs = type == 0 ? db.tblJobs.ToList() : db.tblJobs.Where(j => j.Type == type).ToList();
            foreach(var job in tblJobs)
            {
                DaybookModel dbookModel = new DaybookModel(job);
                var customer = db.tblCustomers.FirstOrDefault(c => c.CustID == dbookModel.CustomerID);
                if (customer != null)
                {
                    dbookModel.Customer = new CustomerModel(customer);
                }
                dbooks.Add(dbookModel);

            }

            return dbooks;
        }

        public List<DaybookModel> GetDayBooks(DateTime dateTimeStamp)
        {
            List<DaybookModel> dbooks = new List<DaybookModel>();
            var tblJobs = db.tblJobs.Where(j => j.dtFrom == dateTimeStamp).OrderBy(db => db.JobID).ThenBy(db => db.Time).ToList();
            foreach (var job in tblJobs)
            {
                DaybookModel dbookModel = new DaybookModel(job);
                var customer = db.tblCustomers.FirstOrDefault(c => c.CustID == dbookModel.CustomerID);
                var truck = db.tblTrucks.FirstOrDefault(t => t.Id == dbookModel.TruckId);
                var trailer = db.tblTrailers.FirstOrDefault(t => t.Id == dbookModel.TrailerId);

                if (customer != null)
                {
                    dbookModel.Customer = new CustomerModel(customer);
                }
                if (truck != null)
                {
                    dbookModel.Truck = truck.Name;
                }
                if (trailer != null)
                {
                    dbookModel.Trailer = trailer.Name;
                }
                dbooks.Add(dbookModel);

            }

            return dbooks;
        }

        public DBResult SaveDaybook(DaybookModel job)
        {
            tblJob tblJob = job.JobID != 0 ? db.tblJobs.FirstOrDefault(j => j.JobID == job.JobID) : new tblJob();
            try
            {
                tblJob.Address = job.Address;
                tblJob.Area = job.Area;
                tblJob.BasePrice = job.BasePrice;
                tblJob.CustomerID = job.CustomerID;
                tblJob.CustRef = job.CustRef;
                tblJob.CustomerName = job.CustomerName;
                tblJob.DriverName = job.DriverName;
                tblJob.dtFrom = job.dtFrom;
                tblJob.dtTo = job.dtTo;
                tblJob.Notes = job.Notes;
                tblJob.Time = job.Time;
                tblJob.Journey = job.Journey;
                tblJob.Type = job.Type;
                tblJob.MiscCode = job.MiscCode;
                tblJob.TruckId = job.TruckId;
                tblJob.PinNumber = job.PinNumber;
                tblJob.TrailerId = job.TrailerId;
                tblJob.UseReturn = job.UseReturn;
                tblJob.JobRef = job.JobRef;
                tblJob.InvoiceNo = job.InvoiceNo;
                
                if(job.JobID == 0)
                {
                    tblJob.DriverID = job.DriverID;
                    db.tblJobs.Add(tblJob);
                    if (job.UseReturn)
                    {
                        var dateFrom = Convert.ToDateTime(tblJob.dtFrom).AddDays(1);
                        var dateTo = Convert.ToDateTime(tblJob.dtTo).AddDays(1);

                        var currentDateUsed = dateFrom;
                        while (currentDateUsed < dateTo)
                        {

                            tblJob retJob = new tblJob();
                            retJob.DriverID = job.DriverID;
                            retJob.Address = job.Address;
                            retJob.Area = job.Area;
                            retJob.BasePrice = job.BasePrice;
                            retJob.CustomerID = job.CustomerID;
                            retJob.CustRef = job.CustRef;
                            retJob.CustomerName = job.CustomerName;
                            retJob.DriverName = job.DriverName;
                            retJob.dtFrom = currentDateUsed;
                            retJob.dtTo = job.dtTo;
                            retJob.Notes = job.Notes;
                            retJob.Time = job.Time;
                            retJob.Journey = job.Journey;
                            retJob.Type = job.Type;
                            retJob.MiscCode = dateFrom == dateTo.AddDays(-2) ? string.Format("{0}-RETURNED", job.MiscCode) : job.MiscCode;
                            retJob.TruckId = job.TruckId;
                            retJob.PinNumber = job.PinNumber;
                            retJob.TrailerId = job.TrailerId;
                            retJob.UseReturn = job.UseReturn;
                            retJob.JobRef = job.JobRef;
                            retJob.dtFrom = currentDateUsed;
                            db.tblJobs.Add(retJob);
                            currentDateUsed = currentDateUsed.AddDays(1);
                        }
                    }
                }
                else
                {
                    if (job.IsDuplicate)
                    {
                        if (tblJob.DriverID == job.DriverID)
                        {
                            tblJob.DuplicateOf = job.JobID;
                            var duplicatesFound = db.tblJobs.Count(j => j.DuplicateOf == job.JobID);
                            tblJob.DriverName = string.Format("{0} ({1})", job.DriverName, (duplicatesFound + 2));
                        }

                        tblJob.DriverID = job.DriverID;
                        db.tblJobs.Add(tblJob);
                    }
                }

                db.SaveChanges();
                return new DBResult { ReturnCode = ReturnCode.Success };
            }
            catch(Exception ex)
            {
                return new DBResult { ReturnCode = ReturnCode.Failed, Message = ex.Message };
            }
            
        }
    }
}
