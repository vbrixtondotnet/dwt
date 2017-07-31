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
using DWTTransport.BLL.Model;

namespace DWTTransport.UI.Trailers
{
    public partial class frmTrailer : BaseForm
    {
        Dialogbase currentDialog;
        IDriverService service;
        List<TrailerModel> Trailers;
        public frmTrailer()
        {
            InitializeComponent();

            service = new DriverService() as IDriverService;
            currentDialog = new frmAddTrailer();
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
            Trailers = service.GetTrailers();
            dsTrailer.DataSource = Trailers;
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
                int id = (int)gridView.GetRowCellValue(rowIndex, colId);
                currentDialog.EditForm(id);
            }
        }
    }
}
