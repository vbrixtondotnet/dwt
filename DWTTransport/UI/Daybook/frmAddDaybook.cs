
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
using DWTTransport.BLL.DAL;
using DWTTransport.UI.BaseForms;
using DWTTransport.BLL.Model;

namespace DWTTransport.UI.Daybook
{
    public partial class frmAddDaybook : BaseDialogForm
    {

        private ICustomerService _customerService;
        private IDriverService _driverService;
        private IDaybookService _daybookService;
        private BaseControl addDaybookControl;
        
        public frmAddDaybook() : base("Add/Edit Daybook")
        {
            OnInit();
        }

        public override void SaveForm()
        {
            DaybookModel daybook = (DaybookModel)addDaybookControl.GetFieldValues();
            _daybookService.SaveDaybook(daybook);
            base.SaveForm();
        }

        public override void EditForm(object id)
        {
            int daybookId = (int)id;
            DaybookModel job = daybookId == 0 ? new DaybookModel { JobID = 0, dtFrom = DateTime.Now, dtTo = DateTime.Now } : _daybookService.GetDayBook(daybookId);
            addDaybookControl.PopulateData(job);
            base.EditForm(id);
        }

        public override void EditForm(object id, bool duplicateOnSave)
        {
            int daybookId = (int)id;
            DaybookModel job = daybookId == 0 ? new DaybookModel {  JobID = 0, dtFrom = DateTime.Now, dtTo = DateTime.Now } : _daybookService.GetDayBook(daybookId);
            job.IsDuplicate = duplicateOnSave;
            addDaybookControl.PopulateData(job);
            base.EditForm(id);
        }

        public override void InitServices()
        {
            _customerService = new CustomerService() as ICustomerService;
            _driverService = new DriverService() as IDriverService;
            _daybookService = new DaybookService() as IDaybookService;
            addDaybookControl = new ctrlAddDaybook();
        }

        public override void OnInit()
        {
            addDaybookControl = new ctrlAddDaybook();
            InitServices();
            InitializeComponent();


            InitControl(addDaybookControl);
        }

        public override void CopyRecord()
        {
            MessageBox.Show("Duplicating Record");
            base.CopyRecord();
        }


    }
}
