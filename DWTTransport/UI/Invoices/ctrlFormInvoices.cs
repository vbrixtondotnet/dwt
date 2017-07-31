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
using DWTTransport.Common;
using DWTTransport.BLL.Services;
using DWTTransport.BLL.Model;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DWTTransport.UI.Invoices
{
    public partial class ctrlFormInvoices : BaseControl
    {

        ICustomerService _customerService;
        IDaybookService _daybookService;
        IInvoiceService _invoiceService;
        List<DaybookModel> dataSource;
        public ctrlFormInvoices()
        {
            _customerService = new CustomerService() as ICustomerService;
            _daybookService = new DaybookService() as IDaybookService;
            _invoiceService = new InvoiceService() as IInvoiceService;
            InitializeComponent();
            OnLoad();
        }

        private void OnLoad()
        {

            var customers = _customerService.GetCustomers();
            dataSource = _daybookService.GetDayBooks(0);

            DWTComboBoxItem customerItem = new DWTComboBoxItem { Text = "Select Customer", Value = 0 };
            this.cboCustomer.Items.Add(customerItem);
            
            foreach (var customer in customers)
            {
                customerItem = new DWTComboBoxItem { Text = customer.Name, Value = customer.CustID };
                cboCustomer.Items.Add(customerItem);
            }
            cboCustomer.SelectedIndex = 0;
            this.bsourceInvoice.DataSource = dataSource;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            var invoices = _invoiceService.GetInvoices(customerid, null, null);
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


        private void RefreshInvoiceDataGrid(List<DaybookModel> dsource) {
            dataSource = dsource;
            this.bsourceInvoice.DataSource = dsource;
            this.invoiceGrid.RefreshDataSource();
        }

        private void dateTo_EditValueChanged(object sender, EventArgs e)
        {
            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            DateTime? dateTo = this.dateTo.DateTime;
            DateTime? datefrom = this.dateFrom.DateTime;

            var invoices = _invoiceService.GetInvoices(customerid, datefrom, dateTo);
            this.RefreshInvoiceDataGrid(invoices);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool ignoreDateRange = this.checkBox1.Checked;
            if (ignoreDateRange)
            {
                var allInvoices = _invoiceService.GetInvoices(0, null, null);
                this.RefreshInvoiceDataGrid(allInvoices);
            }
            else
            {
                int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
                DateTime? dateTo = this.dateTo.DateTime;
                DateTime? datefrom = this.dateFrom.DateTime;

                var invoices = _invoiceService.GetInvoices(customerid, datefrom, dateTo);
                this.RefreshInvoiceDataGrid(invoices);
            }
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            var gridView = (GridView)sender;
            int rowIndex = gridView.FocusedRowHandle;

            if (rowIndex > -1)
            {
                int id = (int)gridView.GetRowCellValue(rowIndex, colJobID);
                var job = _daybookService.GetDayBook(id);

                string fileName = string.Format("{0}/Docs/InvoiceTemplate.xls", AppDomain.CurrentDomain.BaseDirectory);


                object oMissing = Missing.Value;

                Microsoft.Office.Interop.Excel.Application ExcelObj =
                    new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook WBook;
                Microsoft.Office.Interop.Excel.Worksheet WSheet1;
                Microsoft.Office.Interop.Excel.Worksheet WSheet2;
                Microsoft.Office.Interop.Excel.Worksheet WSheet3;
                Microsoft.Office.Interop.Excel.Worksheet WSheet4;
                Microsoft.Office.Interop.Excel.Worksheet WSheet5;
                WBook = ExcelObj.Workbooks.Open(fileName,
                    oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing);
                
                WSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Sheets.get_Item(1);
                WSheet1.Cells[1, 2] = job.JobRef;
                WSheet1.Cells[2, 2] = job.DriverName;
                WSheet1.Cells[3, 2] = Convert.ToDateTime(job.dtFrom).ToShortDateString();
                WSheet1.Cells[4, 2] = Convert.ToDateTime(job.dtTo).ToShortDateString();
                WSheet1.Cells[5, 2] = job.CustRef;
                WSheet1.Cells[1, 5] = job.Journey;

                WSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Sheets.get_Item(2);
                WSheet2.Cells[1, 2] = job.JobRef;
                
                WSheet2.Cells[2, 2] = job.DriverName;
                WSheet2.Cells[3, 2] = Convert.ToDateTime(job.dtFrom).ToShortDateString();
                WSheet2.Cells[4, 2] = Convert.ToDateTime(job.dtTo).ToShortDateString();
                WSheet2.Cells[5, 2] = job.CustRef;
                WSheet2.Cells[1, 5] = job.Journey;

                WSheet3 = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Sheets.get_Item(3);
                WSheet3.Cells[1, 2] = job.JobRef;
                WSheet3.Cells[2, 2] = job.DriverName;
                WSheet3.Cells[3, 2] = Convert.ToDateTime(job.dtFrom).ToShortDateString();
                WSheet3.Cells[4, 2] = Convert.ToDateTime(job.dtTo).ToShortDateString();
                WSheet3.Cells[5, 2] = job.CustRef;
                WSheet3.Cells[1, 5] = job.Journey;

                WSheet4 = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Sheets.get_Item(4);
                WSheet4.Cells[1, 2] = job.JobRef;
                WSheet4.Cells[2, 2] = job.DriverName;
                WSheet4.Cells[3, 2] = Convert.ToDateTime(job.dtFrom).ToShortDateString();
                WSheet4.Cells[4, 2] = Convert.ToDateTime(job.dtTo).ToShortDateString();
                WSheet4.Cells[5, 2] = job.CustRef;
                WSheet4.Cells[1, 5] = job.Journey;

                WSheet5 = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Sheets.get_Item(5);
                WSheet5.Cells[1, 2] = job.JobRef;
                WSheet5.Cells[2, 2] = job.DriverName;
                WSheet5.Cells[3, 2] = Convert.ToDateTime(job.dtFrom).ToShortDateString();
                WSheet5.Cells[4, 2] = Convert.ToDateTime(job.dtTo).ToShortDateString();
                WSheet5.Cells[5, 2] = job.CustRef;
                WSheet5.Cells[1, 5] = job.Journey;

                // save
                //WBook.Save();// or use SaveAs() method to save in a different path.

                ExcelObj.Visible = true;

                Marshal.ReleaseComObject(WSheet1);
                Marshal.ReleaseComObject(WSheet2);
                Marshal.ReleaseComObject(WSheet3);
                Marshal.ReleaseComObject(WSheet4);
                Marshal.ReleaseComObject(WSheet5);
                Marshal.ReleaseComObject(WBook);
                Marshal.ReleaseComObject(ExcelObj);
                WSheet1 = null;
                WBook = null;
                ExcelObj = null;
                GC.Collect();
            }
        }
    }
}
