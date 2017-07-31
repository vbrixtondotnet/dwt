using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWTTransport.BLL.Model;
using DWTTransport.BLL.Services.Interfaces;
using DWTTransport.BLL.Services;
using DWTTransport.BLL.DAL;

namespace DWTTransport.UI.Trucks
{
    public partial class ctrlAddEditTrucks : BaseForms.BaseControl
    {
        ICustomerService customerService;
        JourneyModel currentData;
        public ctrlAddEditTrucks()
        {
            InitializeComponent();
            customerService = new CustomerService() as ICustomerService;
        }
        
        public override object GetFieldValues()
        {
            //var customerId = txtCustomer.EditValue == null ? 0 : Convert.ToInt32(this.txtCustomer.EditValue);
            JourneyModel model = new JourneyModel { Journey = txtJourney.Text, Base = Convert.ToDecimal(txtBase.Text), ID = currentData.ID };
            return model;
        }
        public override void PopulateData(object data)
        {
            currentData = (JourneyModel)data;

            List<tblCustomer> customers = customerService.GetCustomers();

            dsCustomer.DataSource = customers;
            this.txtJourney.Text = currentData.Journey;
            this.txtBase.Text = currentData.Base.ToString();
            //this.txtCustomer.EditValue = currentData.CustomerId;
        }
    }
}
