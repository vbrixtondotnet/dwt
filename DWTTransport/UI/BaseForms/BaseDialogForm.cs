using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWTTransport.UI.BaseForms
{
    public partial class BaseDialogForm : Dialogbase
    {
       
        public BaseDialogForm()
        {
            InitializeComponent();
           
        }
        public BaseDialogForm(string text)
        {
            InitializeComponent();
            this.Text = text;

        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        public void InitControl(Control control)
        {
            control.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(control, 0, 0);
        }

        public virtual void InitServices()
        {
            return;
        }

        public virtual void OnInit()
        {
            return;
        }
    }
}
