using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.UI.BaseForms
{
    public class Dialogbase : DevExpress.XtraEditors.XtraForm
    {
        public delegate void OnSaveFormEvent();
        public OnSaveFormEvent OnSaveForm;

        public delegate void OnCancelFormEvent();
        public OnSaveFormEvent OnCancelForm;


        public delegate void OnCopyFormEvent();
        public OnCopyFormEvent OnCopyForm;

        public virtual void InitDialog()
        {
            return;
        }

        public virtual void SaveForm()
        {
            OnSaveForm?.Invoke();
            this.Close();
        }

        public virtual void Cancel()
        {
            OnCancelForm?.Invoke();
            this.Close();
        }

        public virtual void EditForm(object id)
        {
            this.ShowDialog();
        }

        public virtual void EditForm(object id, bool duplicateOnSave)
        {
            this.ShowDialog();
        }

        public virtual void CopyRecord()
        {
            OnCopyForm?.Invoke();
            this.Close();
        }

    }
}
