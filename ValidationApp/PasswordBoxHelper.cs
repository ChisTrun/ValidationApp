using System.Windows.Controls;
using System.Windows;
namespace ValidationApp { 

public static class PasswordBoxHelper
{
    public static readonly DependencyProperty BoundPasswordProperty =
        DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper),
        new FrameworkPropertyMetadata(string.Empty, OnBoundPasswordChanged));

    public static string GetBoundPassword(DependencyObject obj)
    {
        return (string)obj.GetValue(BoundPasswordProperty);
    }

    public static void SetBoundPassword(DependencyObject obj, string value)
    {
        obj.SetValue(BoundPasswordProperty, value);
    }

    private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is PasswordBox passwordBox)
        {
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if (e.NewValue is string newValue && passwordBox.Password != newValue)
            {
                passwordBox.Password = newValue;
            }

            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }
    }

    private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (sender is PasswordBox passwordBox)
        {
            SetBoundPassword(passwordBox, passwordBox.Password);
        }
    }
}
    }