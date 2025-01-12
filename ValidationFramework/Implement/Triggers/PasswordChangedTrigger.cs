using System.Windows;
using System.Windows.Controls;
using ValidationFramework.Base;

namespace ValidationLib.Trigger;

public class PasswordChangedTrigger : BaseTrigger
{
    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        TriggerValidate();
    }

    public override void Attach()
    {
        if (_control is PasswordBox passwordBox)
        {
            passwordBox.PasswordChanged += OnPasswordChanged;
        }
    }

    public override void Detach()
    {
        if (_control is PasswordBox passwordBox)
        {
            passwordBox.PasswordChanged -= OnPasswordChanged;
        }
    }
}
