using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWTTransport.UI
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        
        public DateTime SelectedDate { get { return this.baseMonthCalendar.SelectionStart; } }
        public BaseForm()
        {
            InitializeComponent();
            this.baseMonthCalendar.SelectionStart = DateTime.Today.AddMonths(-4);
            //this.baseMonthCalendar.date
        }


        public Control CurrentControl { get; set; }
        public virtual void GetData()
        {
            return;
        }

        public virtual void EditForm(GridView gridView)
        {
            return;
        }

        public virtual void OnMonthCalendarDateSelected(DateTime dateTime)
        {
            return;
        }

        private void baseMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            OnMonthCalendarDateSelected(SelectedDate);
        }

        public void InitControl(Control control)
        {
            control.Dock = DockStyle.Fill;
            control.Padding = new Padding(10, 15, 10, 10);
            this.panel2.Controls.Add(control);
        }
    }
}
