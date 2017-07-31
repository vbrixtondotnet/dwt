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

namespace DWTTransport.UI.Drivers
{
    public partial class frmDrivers : BaseForm
    {
        Dialogbase currentDialog;
        IDriverService driverService;
        public frmDrivers()
        {
            InitializeComponent();

            driverService = new DriverService() as IDriverService;

            currentDialog = new frmAddDriver();
            currentDialog.OnSaveForm += new Dialogbase.OnSaveFormEvent(this.GetData);

        }
        
        public override void GetData()
        {
            dsImports.DataSource = driverService.GetDrivers();
        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            EditForm((GridView)sender);
        }

        public override void EditForm(GridView gridView)
        {
            int rowIndex = gridView.FocusedRowHandle;

            if (rowIndex > -1)
            {
                int id = (int)gridView.GetRowCellValue(rowIndex, colDriverID);
                currentDialog.EditForm(id);
            }
        }
    }
}
