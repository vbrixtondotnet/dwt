
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
using DWTTransport.UI.BaseForms;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Model;

namespace DWTTransport.UI.Trailers
{
    public partial class frmAddTrailer : BaseDialogFormSmall
    {

        private ICustomerService _customerService;
        private IDriverService _driverService;
        private ctrlAddEditTrailer currentControl;
        public frmAddTrailer() : base("Add/Edit Customer")
        {
            _customerService = new CustomerService() as ICustomerService;
            _driverService = new DriverService() as IDriverService;
            currentControl = new ctrlAddEditTrailer();

            InitializeComponent();

            InitControl(currentControl);
        }

        public override void SaveForm()
        {
            TrailerModel trailer = (TrailerModel)currentControl.GetFieldValues();
            //_driverService.save(journey);
            base.SaveForm();
        }
        
        public override void EditForm(object id)
        {
            int trailerId = (int)id;
            //TrailerModel trailer = trailerId == 0 ?  new TrailerModel() : _driverService.get(journeyId);
            //currentControl.PopulateData(customer);
            base.EditForm(id);
        }

    }
}
