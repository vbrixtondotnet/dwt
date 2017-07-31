using DWTTransport.BLL.Services;
using DWTTransport.BLL.Services.Interfaces;
using DWTTransport.UI.BaseForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace DWTTransport.UI.Customer
{
    public partial class frmCustomer : BaseForm
    {
        Dialogbase currentDialog;
        public frmCustomer()
        {
            InitializeComponent();

            currentDialog = new frmAddCustomer();
            currentDialog.OnSaveForm += new Dialogbase.OnSaveFormEvent(this.GetData);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //frmDaybookDialog.ShowDialog();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public override void GetData()
        {
            CustomerService customerService = new CustomerService();
            var service = (ICustomerService)customerService;

            dsCustomer.DataSource = service.GetCustomers();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            EditForm((GridView)sender);
        }

        public override void EditForm(GridView gridView)
        {
            int rowIndex = gridView.FocusedRowHandle;

            currentDialog = new frmAddCustomer();
            currentDialog.OnSaveForm += new Dialogbase.OnSaveFormEvent(this.GetData);
            if (rowIndex > -1)
            {
                int id = (int)gridView.GetRowCellValue(rowIndex, colCustID);
                currentDialog.EditForm(id);
            }
        }
    }
}
