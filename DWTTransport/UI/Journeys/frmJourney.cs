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

namespace DWTTransport.UI.Journeys
{
    public partial class frmJourney : BaseForm
    {
        Dialogbase currentDialog;
        IJourneyService service;
        List<JourneyModel> Journeys;
        public frmJourney()
        {
            InitializeComponent();

            service = new JourneyService() as IJourneyService;
            currentDialog = new frmAddJourney();
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
            Journeys = service.GetJourneys();
            dsCustomer.DataSource = Journeys;
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
                int id = (int)gridView.GetRowCellValue(rowIndex, colID);
                currentDialog.EditForm(id);
            }
        }
    }
}
