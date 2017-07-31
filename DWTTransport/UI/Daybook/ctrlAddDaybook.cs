using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Services.Interfaces;
using DWTTransport.BLL.Services;
using DWTTransport.Common;
using DWTTransport.BLL.Model;

namespace DWTTransport.UI.Daybook
{
    public partial class ctrlAddDaybook : BaseForms.BaseControl
    {
        ICustomerService _customerService;
        IDriverService _driverService;
        IJourneyService _journeyService;
        IDaybookService _dayBookService;

        List<JourneyModel> journeys = new List<JourneyModel>();
        public ctrlAddDaybook()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _driverService = new DriverService();
            _journeyService = new JourneyService();
            _dayBookService = new DaybookService();


        }

        public override void PopulateData(object data)
        {
            DaybookModel currentData = (DaybookModel)data;

            var customers = _customerService.GetCustomers();
            var drivers = _driverService.GetDrivers();
            journeys = _journeyService.GetJourneys();
            var trucks = _driverService.GetTrucks();
            var trailers = _driverService.GetTrailers();


            cboCustomer.Items.Clear();
            cboDriver.Items.Clear();
            cboJourney.Items.Clear();
            cboTrailer.Items.Clear();
            cboTruck.Items.Clear();


            this.txtCustomerRef.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtbasePrice.Text = string.Empty;
            this.txtArea.Text = string.Empty;
            this.txtGeneralNotes.Text = string.Empty;
            this.txtMiscCode.Text = string.Empty;
            this.txtInvoice.Text = string.Empty;
            this.txtTime.Text = string.Empty;
            this.txtJobRef.Text = string.Empty;
            this.chkDulicate.Checked = currentData.IsDuplicate;
            this.chkUseReturn.Checked = currentData.UseReturn;

            int index = 1;

            DWTComboBoxItem journeyItem = new DWTComboBoxItem { Text = "Select Journey", Value = 0 };
            cboJourney.Items.Add(journeyItem);

            int selectedJourneyIndex = 0;
            foreach (var journey in journeys)
            {
                journeyItem = new DWTComboBoxItem { Text = journey.Journey, Value = journey.ID };
                cboJourney.Items.Add(journeyItem);

                if (journey.Journey == currentData.Journey)
                {
                    selectedJourneyIndex = index;
                }
                index++;
            }

            int importExport = Convert.ToInt32(currentData.Type) == 1 ? 0 : 1;
            DWTComboBoxItem customerItem = new DWTComboBoxItem { Text = "Select Customer", Value = 0 };
            cboCustomer.Items.Add(customerItem);


            index = 1;
            int selectedCustomerIndex = 0;
            foreach (var customer in customers)
            {
                customerItem = new DWTComboBoxItem { Text = customer.Name, Value = customer.CustID };
                cboCustomer.Items.Add(customerItem);
                if(customer.CustID == currentData.CustomerID)
                {
                    selectedCustomerIndex = index;
                }
                index++;
            }

            DWTComboBoxItem driverItem = new DWTComboBoxItem { Text = "Select Driver", Value = 0 };
            cboDriver.Items.Add(driverItem);

            index = 1;
            int selectedDriverIndex = 0;
            foreach (var driver in drivers)
            {
                driverItem = new DWTComboBoxItem { Text = string.Format("{0} {1}", driver.Name, driver.Surname), Value = driver.DriverID };
                cboDriver.Items.Add(driverItem);
                if (driver.DriverID == currentData.DriverID)
                {
                    selectedDriverIndex = index;
                }
                index++;
            }

            DWTComboBoxItem truckItem = new DWTComboBoxItem { Text = "Select Truck", Value = 0 };
            cboTruck.Items.Add(truckItem);

            index = 1;
            int selectedTruckIndex = 0;
            foreach (var truck in trucks)
            {
                truckItem = new DWTComboBoxItem { Text = string.Format("{0}-{1}", truck.Name, truck.TruckNumber), Value = truck.Id };
                cboTruck.Items.Add(truckItem);

                if (truck.Id == currentData.TruckId)
                {
                    selectedTruckIndex = index;
                }
                index++;
            }

            DWTComboBoxItem trailerItem = new DWTComboBoxItem { Text = "Select Trailer", Value = 0 };
            cboTrailer.Items.Add(trailerItem);

            index = 1;
            int selectedTrailerIndex = 0;
            foreach (var trailer in trailers)
            {
                trailerItem = new DWTComboBoxItem { Text = string.Format("{0}-{1}", trailer.Name, trailer.TrailerName), Value = trailer.Id };
                cboTrailer.Items.Add(trailerItem);

                if (trailer.Id == currentData.TrailerId)
                {
                    selectedTrailerIndex = index;
                }
                index++;
            }

            this.txtCustomerRef.Text = currentData.CustRef;
            this.txtAddress.Text = currentData.Address;
            this.txtbasePrice.Text = currentData.BasePrice.ToString();
            this.txtArea.Text = currentData.Area;
            this.txtGeneralNotes.Text = currentData.Notes;
            this.txtMiscCode.Text = currentData.MiscCode;
            this.txtInvoice.Text = currentData.InvoiceNo;
            this.txtTime.Text = currentData.Time != null ? Convert.ToDateTime(currentData.Time).TimeOfDay.ToString() : DateTime.Now.TimeOfDay.ToString();
            this.cboCustomer.SelectedIndex = selectedCustomerIndex;
            this.cboDriver.SelectedIndex = selectedDriverIndex;
            this.cboTruck.SelectedIndex = selectedTruckIndex;
            this.cboTrailer.SelectedIndex = selectedTrailerIndex;

            if (cboJourney.Items.Count > 0)
            {
                this.cboJourney.SelectedIndex = selectedJourneyIndex;
            }

            if (cboImportExport.Items.Count > 0)
            {
                this.cboImportExport.SelectedIndex = importExport;
            }

            this.txtJobRef.Text = currentData.JobRef;
            this.hdnJobId.Text = currentData.JobID.ToString();
            this.dateFrom.DateTime = Convert.ToDateTime(currentData.dtFrom);
            this.dateTo.DateTime = Convert.ToDateTime(currentData.dtTo);
            this.txtPin.Text = currentData.PinNumber;
            


            var addresses = _dayBookService.GetAdresses();

            AutoCompleteStringCollection addressSuggestions = new AutoCompleteStringCollection();
            addresses.ForEach(add => addressSuggestions.Add(add));
            txtAddress.AutoCompleteCustomSource = addressSuggestions;
            txtAddress.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtAddress.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        public override object GetFieldValues()
        {
            int id = this.hdnJobId.Text == string.Empty ? 0 : Convert.ToInt32(this.hdnJobId.Text);

            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;
            string customerName = (string)((DWTComboBoxItem)cboCustomer.SelectedItem).Text;
            int driverId = (int)((DWTComboBoxItem)cboDriver.SelectedItem).Value;
            string driverName = (string)((DWTComboBoxItem)cboDriver.SelectedItem).Text;
            int truckId = (int)((DWTComboBoxItem)cboTruck.SelectedItem).Value;
            int trailerId = (int)((DWTComboBoxItem)cboTrailer.SelectedItem).Value;

            string journey = ((DWTComboBoxItem)cboJourney.SelectedItem).Text;
            int type = cboImportExport.SelectedItem.ToString().ToUpper() == "IMPORT" ? 1 : 2;
            DaybookModel daybookModel = new DaybookModel
            {
                JobID = id,
                Address = txtAddress.Text,
                Area = txtArea.Text,
                BasePrice = Convert.ToDecimal(txtbasePrice.Text),
                CustomerID = customerid,
                CustRef = txtCustomerRef.Text,
                DriverID = driverId,
                dtFrom = dateFrom.DateTime,
                dtTo = dateTo.DateTime,
                Time = txtTime.Time,
                MiscCode = txtMiscCode.Text,
                Type = type,
                InvoiceNo = txtInvoice.Text,
                JobRef = txtJobRef.Text,
                Notes = txtGeneralNotes.Text,
                Journey = cboJourney.SelectedItem.ToString(),
                CustomerName = customerName,
                DriverName = driverName,
                IsDuplicate = chkDulicate.Checked,
                TruckId = truckId,
                TrailerId = trailerId,
                PinNumber = txtPin.Text, UseReturn = chkUseReturn.Checked
            };

            return daybookModel;
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerid = (int)((DWTComboBoxItem)cboCustomer.SelectedItem).Value;

            cboJourney.Items.Clear();
            DWTComboBoxItem journeyItem;
            foreach (var journey in journeys)
            {
                if (journey.CustomerId == customerid)
                {
                    journeyItem = new DWTComboBoxItem { Text = journey.Journey, Value = journey.ID };
                    cboJourney.Items.Add(journeyItem);
                }
            }
        }
    }
}
