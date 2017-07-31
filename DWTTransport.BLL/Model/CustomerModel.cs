using DWTTransport.BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Model
{
    public class CustomerModel
    {

        public CustomerModel() { }
        public CustomerModel(tblCustomer customer)
        {
            this.Colour = Convert.ToInt32(customer.Colour);
            this.DeliveryAddress = customer.DeliveryAddress;
            this.Name = customer.Name;
            this.Id = customer.CustID;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Colour { get; set; }
        public string DeliveryAddress { get; set; }

        public List<JourneyModel> Journeys { get; set; }
    }
}
