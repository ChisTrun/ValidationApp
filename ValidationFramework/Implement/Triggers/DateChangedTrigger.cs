using System.Windows.Controls;
using ValidationFramework.Base;

namespace ValidationLib.Trigger
{
    public class DateChangedTrigger : BaseTrigger
    {
        private void OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            TriggerValidate();
        }

        public override void Attach()
        {
            if (_control is DatePicker datePicker)
            {
                datePicker.SelectedDateChanged += OnSelectedDateChanged;
            }
        }

        public override void Detach()
        {
            if (_control is DatePicker datePicker)
            {
                datePicker.SelectedDateChanged -= OnSelectedDateChanged;
            }
        }
    }
}
