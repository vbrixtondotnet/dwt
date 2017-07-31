using DWTTransport.BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Model
{
    public class TruckModel
    {
        public TruckModel() { }
        public TruckModel(tblTruck truck)
        {
            this.Id = truck.Id;
            this.Name = truck.Name;
            this.TruckNumber = truck.TruckNumber;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TruckNumber { get; set; }
    }
}
