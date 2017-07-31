using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Model;
using DWTTransport.BLL.Services.Interfaces;

namespace DWTTransport.BLL.Services
{
    public class InvoiceService : IInvoiceService
    {
        private DWTEntities db;
        
        public InvoiceService()
        {
            db = new DWTEntities();
        }

        public List<DaybookModel> GetInvoices(int customerId, DateTime? dateFrom, DateTime? dateTo, int driverId = 0, int truckId = 0, int trailerId = 0)
        {
            List<DaybookModel> retval = new List<DaybookModel>();

            var invoices = customerId == 0 ? db.tblJobs.ToList() : db.tblJobs.Where(j => j.CustomerID == customerId).ToList();
            if (dateFrom != null && dateFrom != DateTime.MinValue)
            {
                invoices = invoices.Where(j => j.dtFrom >= dateFrom).ToList();
            }
            if (dateFrom != null && dateTo != DateTime.MinValue)
            {
                invoices = invoices.Where(j => j.dtTo <= dateTo).ToList();
            }
            if(driverId != 0)
            {
                invoices = invoices.Where(j => j.DriverID == driverId).ToList();
            }
            if(truckId != 0)
            {
                invoices = invoices.Where(j => j.TruckId == truckId).ToList();
            }
            if (trailerId != 0)
            {
                invoices = invoices.Where(j => j.TrailerId == trailerId).ToList();
            }

            foreach (var invoice in invoices)
            {
                DaybookModel dbookModel = new DaybookModel(invoice);
                var customer = db.tblCustomers.FirstOrDefault(c => c.CustID == dbookModel.CustomerID);

                if (customer != null)
                {
                    dbookModel.Customer = new CustomerModel(customer);
                }
                retval.Add(dbookModel);

            }

            //invoices.ForEach(inv => retval.Add(new DaybookModel(inv)));

            return retval;
        }
    }
}
