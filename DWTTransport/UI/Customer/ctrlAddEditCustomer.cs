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

namespace DWTTransport.UI.Customer
{
    public partial class ctrlAddEditCustomer : BaseForms.BaseControl
    {
        IJourneyService journeyService;
        List<JourneyModel> journeys;
        List<JourneyModel> addedJourneys;
        CustomerModel currentData;
        public ctrlAddEditCustomer()
        {
            InitializeComponent();
            journeyService = new JourneyService();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public override object GetFieldValues()
        {
            List<JourneyModel> journeys = (List<JourneyModel>)bsJourneys.List;
            //int id = hdnCustomerId.Text == string.Empty ? 0 : Convert.ToInt32(hdnCustomerId.Text);
            return new CustomerModel { Name = this.txtCustomerName.Text, Colour = txtColour.Color.ToArgb(), DeliveryAddress = txtDeliveryAddress.Text, Id = currentData.Id, Journeys = journeys };
        }
        public override void PopulateData(object data)
        {
            currentData = (CustomerModel)data;
            addedJourneys = new List<JourneyModel>();
            if (currentData.Colour != 0)
            {
                this.txtColour.Color = Color.FromArgb(currentData.Colour);
            }

            addedJourneys = currentData.Journeys;
            this.txtCustomerName.Text = currentData.Name;
            this.txtDeliveryAddress.Text = currentData.DeliveryAddress;
            journeys = journeyService.GetJourneys();
            this.bindingSource1.DataSource = journeys;
            this.bsJourneys.DataSource = addedJourneys;
            //this.hdnCustomerId.Text = customerModel.Id.ToString();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            JourneyModel selectedJourney = (JourneyModel)e.Row;
            selectedJourney = journeys.FirstOrDefault(j => j.Journey == selectedJourney.Journey);

            JourneyModel dsJourney = addedJourneys.FirstOrDefault(j => j.Journey == selectedJourney.Journey);
            dsJourney.ID = selectedJourney.ID;
            dsJourney.Base = selectedJourney.Base;
            dsJourney.Gen_Journey = selectedJourney.Gen_Journey;
        }
        
    }
}
