
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

namespace DWTTransport.UI.Trucks
{
    public partial class frmAddTruck : BaseDialogFormSmall
    {

        private ICustomerService _customerService;
        private IJourneyService _journeyService;
        private ctrlAddEditTrucks currentControl;
        public frmAddTruck() : base("Add/Edit Customer")
        {
            _customerService = new CustomerService() as ICustomerService;
            _journeyService = new JourneyService() as IJourneyService;
            currentControl = new ctrlAddEditTrucks();

            InitializeComponent();

            InitControl(currentControl);
        }

        public override void SaveForm()
        {
            JourneyModel journey = (JourneyModel)currentControl.GetFieldValues();
            _journeyService.SaveJourney(journey);
            base.SaveForm();
        }
        
        public override void EditForm(object id)
        {
            int journeyId = (int)id;
            JourneyModel customer = journeyId == 0 ?  new JourneyModel() : _journeyService.GetJourney(journeyId);
            currentControl.PopulateData(customer);
            base.EditForm(id);
        }

    }
}
