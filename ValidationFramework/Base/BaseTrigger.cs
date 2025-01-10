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
        protected TextBox? _textBox = null;
        public void SetTextBox(TextBox textBox)
        {
            _textBox = textBox;
        }

        protected void TriggerValidate()
        {
            if (_textBox == null)
            {
                throw new InvalidOperationException("TextBox is not set.");
            }
            ValidationAttachedProperties.GetObserver(_textBox).Validate(_textBox.Text);
        }

        public abstract void Attach();
        public abstract void Detach();
    }
}
