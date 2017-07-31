using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Model;
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

namespace DWTTransport.UI.Daybook
{
    public partial class frmDaybook : BaseForm
    {
        IDaybookService service;
        Dialogbase currentDialog;
        List<DaybookModel> imports;
        List<DaybookModel> exports;
        List<DaybookModel> daybookList;

        bool dataLoaded = false;
        public frmDaybook()
        {


            DaybookService daybookService = new DaybookService();
            service = (IDaybookService)daybookService;
            InitializeComponent();

            //InitializeMenuItems();

            currentDialog = new frmAddDaybook();
            currentDialog.OnSaveForm += new Dialogbase.OnSaveFormEvent(this.GetData);

        }

        private void frmDaybook_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public override void GetData()
        {
            daybookList = service.GetDayBooks(this.SelectedDate);

            dataLoaded = true;
            RefreshGridViews();

        }

        private void RefreshDataByDate(DateTime datetime)
        {
            if (service == null || !dataLoaded) return;

            daybookList = service.GetDayBooks(datetime);

            RefreshGridViews();
        }

        private void frmDaybook_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            EditForm((GridView)sender);
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            EditForm((GridView)sender);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            EditForm((GridView)sender);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            EditForm((GridView)sender);
        }

        public override void EditForm(GridView gridView)
        {
            int rowIndex = gridView.FocusedRowHandle;

            if (rowIndex > -1)
            {
                int id = (int)gridView.GetRowCellValue(rowIndex, colJobID);
                currentDialog.EditForm(id);
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            AddColumnTextColor("Address", sender, e);
        }

        private void gridView3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            AddColumnTextColor("MiscCode", sender, e);
        }
        private void gridView4_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            AddColumnTextColor("MiscCode", sender, e);
        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            AddColumnTextColor("Address", sender, e);
        }
        private void AddColumnTextColor(string columnName, object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            //if (e.Column.FieldName == columnName)
            //{
            try
            {
                int type = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Type"]));
                int jobId = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["JobID"]));
                //var dsource = type == 1 ? imports : exports;
                CustomerModel customerModel = daybookList.FirstOrDefault(db => db.JobID == jobId) != null ? daybookList.FirstOrDefault(db => db.JobID == jobId).Customer : null;

                if (customerModel == null) return;

                e.Appearance.ForeColor = Color.FromArgb(customerModel.Colour);
            }
            catch (Exception ex) { }
            //}
        }

        public override void OnMonthCalendarDateSelected(DateTime dateTime)
        {
            RefreshDataByDate(dateTime);
        }

        private void RefreshGridViews()
        {

            List<DaybookModel> exportsByDriver = daybookList.GroupBy(x => x.DriverID).Select(x => x.First()).ToList();
            exports = daybookList.Where(db => db.Type == 2).ToList();
            imports = daybookList.Where(db => db.Type == 1).ToList();
            //List<DaybookModel> importsByDriver = imports.GroupBy(x => x.DriverID).Select(x => x.First()).ToList();

            List<DaybookModel> dsExports = new List<DaybookModel>();
            List<DaybookModel> dsImports = new List<DaybookModel>();

            foreach (var driver in exportsByDriver)
            {
                var exportCount = exports.Count(exp => exp.DriverID == driver.DriverID);
                var importCount = imports.Count(exp => exp.DriverID == driver.DriverID);
                var hasMoreExportRows = exportCount > importCount;
                int blankRows = hasMoreExportRows ? (exportCount - importCount) : (importCount - exportCount);

                List<DaybookModel> sourceDs = hasMoreExportRows ? exports : imports;
                List<DaybookModel> sourceDs2 = !hasMoreExportRows ? exports : imports;

                List<DaybookModel> gviewDs = hasMoreExportRows ? dsExports : dsImports;
                List<DaybookModel> dsToAddBlankRows = !hasMoreExportRows ? dsExports : dsImports;

                sourceDs.Where(exp => exp.DriverID == driver.DriverID).ToList().ForEach(expd => gviewDs.Add(expd));
                sourceDs2.Where(exp => exp.DriverID == driver.DriverID).ToList().ForEach(expd => dsToAddBlankRows.Add(expd));

                for (var index = 0; index < blankRows; index++)
                {
                    dsToAddBlankRows.Add(new DaybookModel() { JobID = 0, DriverID = 0, CustomerID = 0 });
                }

            }




            this.dsImportsDetailed.DataSource = imports;
            this.dsExportDetails.DataSource = exports;
            this.dsExports.DataSource = dsExports;
            this.dsImports.DataSource = dsImports;

            gridView1.RefreshData();
            gridView2.RefreshData();
            gridView3.RefreshData();
            gridView4.RefreshData();
        }

        private void gridView3_TopRowChanged(object sender, EventArgs e)
        {
            gridView4.TopRowIndex = gridView3.TopRowIndex;
        }

        private void gridView4_TopRowChanged(object sender, EventArgs e)
        {
            gridView3.TopRowIndex = gridView4.TopRowIndex;
        }

        private void gridView3_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            OnPopupMenuShowing(sender, e);
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            OnPopupMenuShowing(sender, e);
        }

        private void Item_Click1(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            var id = item.Tag;

            currentDialog = new frmAddDaybook();
            currentDialog.OnSaveForm += new Dialogbase.OnSaveFormEvent(this.GetData);
            currentDialog.EditForm(id, true);
        }
        

        #region ContextMenus
        DXMenuItem[] menuItems;
        void InitializeMenuItems()
        {
            DXMenuItem itemEdit = new DXMenuItem("Duplicate Order");
            menuItems = new DXMenuItem[] { itemEdit };
        }


        private void OnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                InitializeMenuItems();
                GridView view = sender as GridView;
                view.FocusedRowHandle = e.HitInfo.RowHandle;

                int rowIndex = view.FocusedRowHandle;
                int id = rowIndex > -1 ? (int)view.GetRowCellValue(rowIndex, colJobID) : 0;

                //if (radioGroup1.EditValue.ToString() == "Standard Menu")
                contextMenuStrip1.Show(view.GridControl, e.Point);

                //if (radioGroup1.EditValue.ToString() == "DevExpress Menu")
                //{
                foreach (DXMenuItem item in menuItems)
                {
                    item.Tag = id;
                    item.Click += Item_Click1;
                    e.Menu.Items.Add(item);
                }
            }
        }
        #endregion

        private void gridView4_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            OnPopupMenuShowing(sender, e);
        }

        private void gridView2_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            OnPopupMenuShowing(sender, e);
        }
    }
}
