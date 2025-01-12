using System.Windows;
using System.Windows.Controls;
using ValidationFramework.Base;

namespace ValidationLib.Trigger;

public class CheckBoxCheckedTrigger : BaseTrigger
{
    private void OnCheckedChanged(object sender, RoutedEventArgs e)
    {
        TriggerValidate();
    }

    public override void Attach()
    {
        if (_control is CheckBox checkBox)
        {
            checkBox.Checked += OnCheckedChanged;
            checkBox.Unchecked += OnCheckedChanged;
        }
    }

    public override void Detach()
    {
        if (_control is CheckBox checkBox)
        {
            checkBox.Checked -= OnCheckedChanged;
            checkBox.Unchecked -= OnCheckedChanged;
        }
    }
}
