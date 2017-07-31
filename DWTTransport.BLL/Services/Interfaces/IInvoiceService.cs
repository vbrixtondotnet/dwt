using DWTTransport.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Services.Interfaces
{
    public interface IInvoiceService
    {
        List<DaybookModel> GetInvoices(int customerId, DateTime? dateFrom, DateTime? dateTo, int driverId = 0, int truckId = 0, int trailerId = 0);
    }
}
