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
    public class CustomerService : ICustomerService
    {
        private DWTEntities db;
        
        public CustomerService()
        {
            db = new DWTEntities();
        }

        public CustomerModel GetCustomer(int id)
        {
            var dbCustomer = db.tblCustomers.FirstOrDefault(c => c.CustID == id);
            var customer = new CustomerModel { Colour = Convert.ToInt32(dbCustomer.Colour), DeliveryAddress = dbCustomer.DeliveryAddress, Name = dbCustomer.Name, Id = dbCustomer.CustID, Journeys = new List<JourneyModel>()};
            var journeys = db.tblJourneys.Where(j => j.CustomerId == dbCustomer.CustID).ToList();

            journeys.ForEach(j => customer.Journeys.Add(new JourneyModel(j)));

            return customer;
        }

        public List<tblCustomer> GetCustomers()
        {
            return db.tblCustomers.ToList();
        }

        public DBResult SaveCustomer(CustomerModel model)
        {
            tblCustomer customer = model.Id == 0 ? new tblCustomer() : db.tblCustomers.FirstOrDefault(d => d.CustID == model.Id);
            customer.Colour = model.Colour;
            customer.DeliveryAddress = model.DeliveryAddress;
            customer.Name = model.Name;

            try
            {
                if (model.Id == 0)
                {

                    db.tblCustomers.Add(customer);

                    db.SaveChanges();

                    foreach (var journey in model.Journeys)
                    {
                        tblJourney dbJourney = db.tblJourneys.FirstOrDefault(j => j.ID == journey.ID);
                        dbJourney.CustomerId = customer.CustID;
                    }
                }
                else
                {
                    var customerJourneys = db.tblJourneys.Where(j => j.CustomerId == model.Id).ToList();
                    customerJourneys.ForEach(cj => cj.CustomerId = null);
                    db.SaveChanges();

                    foreach (var journey in model.Journeys)
                    {
                        tblJourney dbJourney = db.tblJourneys.FirstOrDefault(j => j.ID == journey.ID);
                        dbJourney.CustomerId = model.Id;
                    }
                }

                db.SaveChanges();
                return new DBResult { ReturnCode = ReturnCode.Success };
            }
            catch (Exception ex)
            {
                return new DBResult { Message = ex.Message, ReturnCode = ReturnCode.Failed };
            }
        }
    }
}
