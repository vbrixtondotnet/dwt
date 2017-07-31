using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWTTransport.UI.BaseForms;
using DWTTransport.BLL.Services.Interfaces;
using DWTTransport.BLL.Services;
using DWTTransport.Common;
using DWTTransport.UI.Daybook;
using DevExpress.XtraGrid.Views.Grid;
using DWTTransport.BLL.Model;

namespace DWTTransport.UI.Workload
{
    public partial class ctrlFormWorkload : BaseControl
    {
        ICustomerService _customerService;
        IDaybookService _daybookService;
        IInvoiceService _invoiceService;
        IDriverService _driverService;
        List<DaybookModel> dataSource;

        frmAddDaybook currentDialog;
        public ctrlFormWorkload()
        {

            _customerService = new CustomerService() as ICustomerService;
            _daybookService = new DaybookService() as IDaybookService;
            _invoiceService = new InvoiceService() as IInvoiceService;
            _driverService = new DriverService() as IDriverService;
            currentDialog = new frmAddDaybook();
            InitializeComponent();

            OnLoad();
        }

        private void OnLoad()
        {

            var customers = _customerService.GetCustomers();
            var drivers = _driverService.GetDrivers();
            var trucks = _driverService.GetTrucks();
            var trailers = _driverService.GetTrailers();
            var dataSource = _daybookService.GetDayBooks(0);

            DWTComboBoxItem customerItem = new DWTComboBoxItem { Text = "Select Customer", Value = 0 };
            this.cboCustomer.Items.Add(customerItem);

            foreach (var customer in customers)
            {
                customerItem = new DWTComboBoxItem { Text = customer.Name, Value = customer.CustID };
                cboCustomer.Items.Add(customerItem);
            }
            cboCustomer.SelectedIndex = 0;

            DWTComboBoxItem driverItem = new DWTComboBoxItem { Text = "Select Driver", Value = 0 };
            this.cboDriver.Items.Add(driverItem);

            foreach (var driver in drivers)
            {
                driverItem = new DWTComboBoxItem { Text = driver.Name, Value = driver.DriverID };
                cboDriver.Items.Add(driverItem);
            }
            cboDriver.SelectedIndex = 0;

            this.bsourceInvoice.DataSource = dataSource;


            DWTComboBoxItem truckItem = new DWTComboBoxItem { Text = "Select Truck", Value = 0 };
            this.cboTrucks.Items.Add(truckItem);

            foreach (var truck in trucks)
            {
                truckItem = new DWTComboBoxItem { Text = String.Format("{0}-{1}", truck.Name, truck.TruckNumber), Value = truck.Id };
                cboTrucks.Items.Add(truckItem);
            }
            cboTrucks.SelectedIndex = 0;

            DWTComboBoxItem trailerItem = new DWTComboBoxItem { Text = "Select Trailer", Value = 0 };
            this.cboTrailers.Items.Add(trailerItem);

            foreach (var trailer in trailers)
            {
                trailerItem = new DWTComboBoxItem { Text = String.Format("{0}-{1}", trailer.Name, trailer.TrailerName), Value = trailer.Id };
                cboTrailers.Items.Add(trailerItem);
            }
            cboTrailers.SelectedIndex = 0;

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var gridView = (GridView)sender;
            int rowIndex = gridView.FocusedRowHandle;

            if (rowIndex > -1)
            {
                int id = (int)gridView.GetRowCellValue(rowIndex, colJobID);
                currentDialog.EditForm(id);
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            var invoices = _invoiceService.GetInvoices(customerid, null, null);
            this.RefreshInvoiceDataGrid(invoices);
        }

        private void cboDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            int driverId = (int)((DWTComboBoxItem)cboDriver.SelectedItem).Value;
            var invoices = _invoiceService.GetInvoices(customerid, null, null, driverId);
            this.RefreshInvoiceDataGrid(invoices);
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            DateTime? datefrom = this.dateFrom.DateTime;
            DateTime? dateTo = this.dateTo.DateTime;

            var invoices = _invoiceService.GetInvoices(customerid, datefrom, dateTo);
            this.RefreshInvoiceDataGrid(invoices);
        }

        private void dateTo_EditValueChanged(object sender, EventArgs e)
        {

            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            DateTime? dateTo = this.dateTo.DateTime;
            DateTime? datefrom = this.dateFrom.DateTime;

            var invoices = _invoiceService.GetInvoices(customerid, datefrom, dateTo);
            this.RefreshInvoiceDataGrid(invoices);
        }

        private void RefreshInvoiceDataGrid(List<DaybookModel> dsource)
        {
            dataSource = dsource;
            this.bsourceInvoice.DataSource = dsource;
            this.invoiceGrid.RefreshDataSource();
        }

        private void AddColumnTextColor(string columnName, object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            //if (e.Column.FieldName == columnName)
            //{
                int jobId = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["JobID"]));

                CustomerModel customerModel = dataSource.FirstOrDefault(db => db.JobID == jobId).Customer;

            if (customerModel != null)
            {
                e.Appearance.ForeColor = Color.FromArgb(customerModel.Colour);
            }
            //}
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            AddColumnTextColor("Address", sender, e);
        }

        private void cboTrucks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            int driverId = (int)((DWTComboBoxItem)cboDriver.SelectedItem).Value;
            int truckId = (int)((DWTComboBoxItem)cboTrucks.SelectedItem).Value;
            int trailerId = cboTrailers.SelectedItem == null ? 0 : (int)((DWTComboBoxItem)cboTrailers.SelectedItem).Value;
            var invoices = _invoiceService.GetInvoices(customerid, null, null, driverId, truckId, trailerId);
            this.RefreshInvoiceDataGrid(invoices);
        }

        private void cboTrailers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            int driverId = (int)((DWTComboBoxItem)cboDriver.SelectedItem).Value;
            int truckId = (int)((DWTComboBoxItem)cboTrucks.SelectedItem).Value;
            int trailerId = (int)((DWTComboBoxItem)cboTrailers.SelectedItem).Value;
            var invoices = _invoiceService.GetInvoices(customerid, null, null, driverId, truckId, trailerId);
            this.RefreshInvoiceDataGrid(invoices);
        }
    }
}
