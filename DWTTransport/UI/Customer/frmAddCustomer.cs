
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWTTransport.BLL.Services.Interfaces;
using DWTTransport.BLL.Services;
using DWTTransport.Common;
using System.Windows.Controls;
using DWTTransport.UI.BaseForms;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Model;

namespace DWTTransport.UI.Customer
{
    public partial class frmAddCustomer : BaseDialogFormSmall
    {

        private ICustomerService _customerService;
        private IDriverService _driverService;
        private ctrlAddEditCustomer currentControl;
        public frmAddCustomer() : base("Add/Edit Customer")
        {
            _customerService = new CustomerService() as ICustomerService;
            _driverService = new DriverService() as IDriverService;
            currentControl = new ctrlAddEditCustomer();

            InitializeComponent();

            InitControl(currentControl);
        }

        public override void SaveForm()
        {
            CustomerModel customer = (CustomerModel)currentControl.GetFieldValues();
             _customerService.SaveCustomer(customer);
            base.SaveForm();
        }
        
        public override void EditForm(object id)
        {
            int customerId = (int)id;
            CustomerModel customer = customerId == 0 ?  new CustomerModel() : _customerService.GetCustomer(customerId);
            if(customerId == 0)
            {
                customer.Journeys = new List<JourneyModel>();
            }
            currentControl.PopulateData(customer);
            base.EditForm(id);
        }

    }
}
