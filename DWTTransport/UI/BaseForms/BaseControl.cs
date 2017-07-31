using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWTTransport.UI.BaseForms
{
    public class BaseControl : UserControl
    {
        public virtual void PopulateData(object data)
        {
            return;
        }

        public virtual object GetFieldValues()
        {
            return null;
        }
    }
}
