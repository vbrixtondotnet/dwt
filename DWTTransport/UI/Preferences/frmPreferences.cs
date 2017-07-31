
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

namespace DWTTransport.UI.Preferences
{
    public partial class frmPreferences : BaseForm
    {

        private ICustomerService _customerService;
        private IDriverService _driverService;
        public frmPreferences()
        {
            _customerService = new CustomerService() as ICustomerService;
            _driverService = new DriverService() as IDriverService;

            InitializeComponent();

            Init();
        }

        private void Init()
        {
            //var customers = _customerService.GetCustomers();
            //var drivers = _driverService.GetDrivers();

            //DWTComboBoxItem customerItem = new DWTComboBoxItem { Text = "Select Customer", Value = 0 };
            ////cboCustomer.Items.Add(customerItem);

            //foreach(var customer in customers)
            //{
            //    customerItem = new DWTComboBoxItem { Text = customer.Name, Value = customer.CustID };
            //    cboCustomer.Items.Add(customerItem);
            //}

            //DWTComboBoxItem driverItem = new DWTComboBoxItem { Text = "Select Driver", Value = 0 };
            //cboDriver.Items.Add(driverItem);

            //foreach (var driver in drivers)
            //{
            //    driverItem = new DWTComboBoxItem { Text = string.Format("{0} {1}", driver.Name, driver.Surname), Value = driver.DriverID };
            //    cboDriver.Items.Add(driverItem);
            //}


        }

        private void dataGridControl_Click(object sender, EventArgs e)
        {

        }
    }
}
