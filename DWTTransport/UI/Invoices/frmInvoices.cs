using DWTTransport.BLL.Services;
using DWTTransport.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWTTransport.UI.Invoices
{
    public partial class frmInvoices : BaseForm
    {
        public frmInvoices()
        {
            CurrentControl = new ctrlFormInvoices();
            InitializeComponent();
            InitControl(CurrentControl);

        }

        private void frmDaybook_Load(object sender, EventArgs e)
        {
            DaybookService daybookService = new DaybookService();
            var service = (IDaybookService)daybookService;

            var exports = service.GetDayBooks(2);
            var imports = service.GetDayBooks(1);
            
            this.dsExports.DataSource = exports;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //frmAddDaybook frmDaybookDialog = new frmAddDaybook();
            //frmDaybookDialog.ShowDialog();
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
