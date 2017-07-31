using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWTTransport.BLL.Model;
using DWTTransport.BLL.Services.Interfaces;
using DWTTransport.BLL.Services;
using DWTTransport.BLL.DAL;

namespace DWTTransport.UI.Trailers
{
    public partial class ctrlAddEditTrailer : BaseForms.BaseControl
    {
        IDriverService driverService;
        TrailerModel currentData;
        public ctrlAddEditTrailer()
        {
            InitializeComponent();
            driverService = new DriverService() as IDriverService;
        }
        
        public override object GetFieldValues()
        {
            //var customerId = txtCustomer.EditValue == null ? 0 : Convert.ToInt32(this.txtCustomer.EditValue);
            JourneyModel model = new JourneyModel { Journey = txtName.Text, Base = Convert.ToDecimal(txtNumber.Text), ID = currentData.Id };
            return model;
        }
        public override void PopulateData(object data)
        {
            currentData = (TrailerModel)data;

            List<TrailerModel> trailers = driverService.GetTrailers();

            dsCustomer.DataSource = trailers;
            this.txtName.Text = currentData.Name;
            this.txtNumber.Text = currentData.TrailerName;
            //this.txtCustomer.EditValue = currentData.CustomerId;
        }
    }
}
