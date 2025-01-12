using System.Windows;
using System.Windows.Controls;
using ValidationFramework.Base;

namespace ValidationLib.Trigger
{
    public class RadioButtonChangedTrigger : BaseTrigger
    {
        private void OnGenderChanged(object? sender, RoutedEventArgs e)
        {
            TriggerValidate();
        }

        public override void Attach()
        {
            if (_control is FrameworkElement element && element is Panel panel)
            {
                foreach (var child in panel.Children)
                {
                    if (child is RadioButton radioButton)
                    {
                        radioButton.Checked += OnGenderChanged;
                    }
                }
            }
        }

        public override void Detach()
        {
            if (_control is FrameworkElement element && element is Panel panel)
            {
                foreach (var child in panel.Children)
                {
                    if (child is RadioButton radioButton)
                    {
                        radioButton.Checked -= OnGenderChanged;
                    }
                }
            }
        }
    }
}
