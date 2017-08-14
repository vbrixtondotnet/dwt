using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DWTTransport.UI.Preferences;
using DWTTransport.UI.Daybook;
using DWTTransport.UI.BaseForms;
using DWTTransport.UI.Customer;
using DWTTransport.UI.Drivers;
using DWTTransport.UI;
using DWTTransport.UI.Journeys;
using DWTTransport.UI.Trucks;
using DWTTransport.UI.Trailers;

namespace DWTTransport
{
    public partial class StartForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string UserID;
        private BaseForm CurrentForm;
        public StartForm()
        {
            InitializeComponent();
            this.dateLabel.Caption = DateTime.Now.ToShortDateString();
            
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void OpenForm<T>(string UserID = "", Guid companyID = new Guid())
        {
            var existingForm = MdiChildren.FirstOrDefault(x => x.GetType() == typeof(T));


            if (existingForm == null)
            {
                T Form = (T)Activator.CreateInstance(typeof(T));

                dynamic f = Form;
                f.MdiParent = this;

                if (!string.IsNullOrEmpty(UserID))
                    f.UserID = UserID;

                if (companyID != Guid.Empty)
                    f.CompanyID = companyID;


                OnFormActivated(f, null);

                f.Show();
                f.Activated += new EventHandler(OnFormActivated);


            }
            else
            {
                existingForm.Activate();
                existingForm.Focus();
                //existingForm.Activated
            }
        }

        public void OnFormActivated(object sender, EventArgs e)
        {
            CurrentForm = (BaseForm)sender;
            this.ribbonPageGroupAddBtn.Visible = true;
            switch (CurrentForm.Text.ToUpper())
            {
                case "DAYBOOK":
                    this.btnAdd.Caption = "Add Daybook";
                    
                    break;
                case "CUSTOMER":
                    this.btnAdd.Caption = "Add Customer";
                    break;
                case "DRIVERS":
                    this.btnAdd.Caption = "Add Driver";
                    break;
                case "JOURNEY":
                    this.btnAdd.Caption = "Add Journey";
                    break;
                case "TRUCKS":
                    this.btnAdd.Caption = "Add Truck";
                    break;
                case "TRAILERS":
                    this.btnAdd.Caption = "Add Trailer";
                    break;

                default:
                    this.ribbonPageGroupAddBtn.Visible = false;
                    break;
            }
        }
        
        
        private void StartForm_Load(object sender, EventArgs e)
        {
            OpenForm<UI.Daybook.frmDaybook>();
        }

        private void btnRawMaterialsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Daybook.frmDaybook>();
        }

        private void btnReceipts_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Customer.frmCustomer>();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Drivers.frmDrivers>();
        }

        private void btnInvoices_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Invoices.frmInvoices>();
        }

        private void btnWorkload_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Workload.frmWorkload>();
        }

        private void btnPreferences_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPreferences formPreferences = new frmPreferences();
            formPreferences.ShowDialog();
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            Dialogbase dialogForm = null;
            switch (btnAdd.Caption.ToUpper())
            {
                case "ADD DAYBOOK":
                    dialogForm = new frmAddDaybook();
                    break;
                case "ADD CUSTOMER":
                    dialogForm = new frmAddCustomer();
                    break;
                case "ADD DRIVER":
                    dialogForm = new frmAddDriver();
                    break;
                case "ADD JOURNEY":
                    dialogForm = new frmAddJourney();
                    break;
                case "ADD TRUCK":
                    dialogForm = new frmAddTruck();
                    break;
                case "ADD TRAILER":
                    dialogForm = new frmAddTrailer();
                    break;
            }

            dialogForm.OnSaveForm += new Dialogbase.OnSaveFormEvent(CurrentForm.GetData);
            dialogForm.EditForm(0);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Users.frmUsers>();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Journeys.frmJourney>();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Trucks.frmTrucks>();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<UI.Trailers.frmTrailer>();
        }
    }
}