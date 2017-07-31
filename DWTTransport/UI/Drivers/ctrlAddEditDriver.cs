using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWTTransport.UI.BaseForms;
using DWTTransport.BLL.Model;

namespace DWTTransport.UI.Drivers
{
    public partial class ctrlAddEditDriver : BaseControl
    {
        public ctrlAddEditDriver()
        {
            InitializeComponent();
        }

        public override object GetFieldValues()
        {
            var id = string.IsNullOrEmpty(hdnDriverId.Text) ? "0" : hdnDriverId.Text;
            return new DriverModel { Id = Convert.ToInt32(id), Name = txtFirstName.Text, Surname = txtSurname.Text };
        }

        public override void PopulateData(object data)
        {
            DriverModel model = (DriverModel)data;
            hdnDriverId.Text = model.Id.ToString();
            txtSurname.Text = model.Surname;
            txtFirstName.Text = model.Name;
        }
    }
}
