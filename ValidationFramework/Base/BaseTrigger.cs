using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ValidationLib.UIControl;

namespace ValidationFramework.Base
{
    public abstract class BaseTrigger
    {
        protected Control? _control = null;
        public void SetControl(Control control)
        {
            _control = control;
        }

        protected void TriggerValidate()
        {
            if (_control == null)
            {
                throw new InvalidOperationException("Control is not set.");
            }

            var observer = ValidationAttachedProperties.GetObserver(_control);

            if (_control is TextBox textBox)
            {
                observer.Validate(textBox.Text);
            }
            else if (_control is PasswordBox passwordBox)
            {
                observer.Validate(passwordBox.Password);
            }
            else
            {
                throw new InvalidOperationException("Unsupported control type.");
            }
        }


        public abstract void Attach();
        public abstract void Detach();
    }
}
