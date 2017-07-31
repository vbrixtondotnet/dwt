using DWTTransport.BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Model
{
    public class DaybookModel
    {

        public DaybookModel() { }
        public DaybookModel(tblJob job)
        {
            this.JobID = job.JobID;
            this.CustomerName = job.CustomerName;
            this.CustomerID = job.CustomerID;
            this.dtTo = job.dtTo;
            this.dtFrom = job.dtFrom;
            this.DriverName = job.DriverName;
            this.DriverTimeStamp = job.DriverTimeStamp;
            this.DriverID = job.DriverID;
            this.MiscCode = job.MiscCode;
            this.Type = job.Type;
            this.JobRef = job.JobRef;
            this.CustRef = job.CustRef;
            this.Area = job.Area;
            this.Journey = job.Journey;
            this.BasePrice = job.BasePrice;
            this.Time = job.Time;
            this.InvoiceNo = job.InvoiceNo;
            this.Notes = job.Notes;
            this.Address = job.Address;
            this.Address = job.Address;
            this.TruckId = job.TruckId;
            this.TrailerId = job.TrailerId;
            this.PinNumber = job.PinNumber;
            this.UseReturn = Convert.ToBoolean(job.UseReturn);
            this.TimeString = job.Time == null ? DateTime.Now.TimeOfDay.ToString() : Convert.ToDateTime(job.Time).TimeOfDay.ToString();
        }
        public int JobID { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.DateTime> dtFrom { get; set; }
        public Nullable<System.DateTime> dtTo { get; set; }
        public string DriverName { get; set; }
        public Nullable<System.DateTime> DriverTimeStamp { get; set; }
        public Nullable<int> DriverID { get; set; }
        public string MiscCode { get; set; }
        public Nullable<int> Type { get; set; }
        public String TypeString { get { return this.Type == 1 ? "Import" : "Export"; } }
        public string JobRef { get; set; }
        public string CustRef { get; set; }
        public string Area { get; set; }
        public string Journey { get; set; }
        public Nullable<decimal> BasePrice { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public string InvoiceNo { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }

        public CustomerModel Customer { get; set; }

        public string TimeString { get; set; }

        public bool IsDuplicate { get; set; }

        public int? TruckId { get; set; }

        public int? TrailerId { get; set; }

        public string Truck { get; set; }

        public string Trailer { get; set; }
        public string PinNumber { get; set; }

        public bool UseReturn { get; set; }

    }
}
