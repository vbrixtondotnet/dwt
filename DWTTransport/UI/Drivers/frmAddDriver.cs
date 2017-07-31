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

namespace DWTTransport.UI.Drivers
{
    public partial class frmAddDriver : BaseDialogFormSmall
    {
        private ctrlAddEditDriver currentControl;
        private IDriverService _driverService;
        public frmAddDriver() : base("Add/Edit Driver")
        {
            InitializeComponent();

            _driverService = new DriverService() as IDriverService;
            currentControl = new ctrlAddEditDriver();
            InitControl(currentControl);
        }

        public override void SaveForm()
        {
            DriverModel driverModel = (DriverModel)currentControl.GetFieldValues();
            _driverService.SaveDriver(driverModel);
            base.SaveForm();
        }

        public override void Cancel()
        {
            base.Cancel();
        }

        public override void EditForm(object id)
        {
            int driverId = (int)id;
            DriverModel driver = driverId == 0 ? new DriverModel() : _driverService.GetDriver(driverId);
            currentControl.PopulateData(driver);
            base.EditForm(id);
        }
    }
}
