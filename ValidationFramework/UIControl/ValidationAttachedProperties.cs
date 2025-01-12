using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationLib.UIControl;

public static class ValidationAttachedProperties
{
  
    /// <summary>
    /// Handler attached property (hidden)
    /// </summary>
    public static readonly DependencyProperty ObserverProperty =
        DependencyProperty.RegisterAttached(
            "Observer",
            typeof(ValidateObserver),
            typeof(ValidationAttachedProperties),
            new PropertyMetadata(null));

    [Category("Validation")]
    [Browsable(true)]
    [DisplayName("Observer")]
    [AttachedPropertyBrowsableForType(typeof(TextBox))]
    public static ValidateObserver GetObserver(DependencyObject element)
    {
        return (ValidateObserver)element.GetValue(ObserverProperty);
    }

    public static void SetObserver(DependencyObject element, ValidateObserver value)
    {
        element.SetValue(ObserverProperty, value);
    }


    /// <summary>
    /// Trigger attached property
    /// </summary>
    public static readonly DependencyProperty TriggerProperty =
        DependencyProperty.RegisterAttached(
            "Trigger",
            typeof(BaseTrigger),
            typeof(ValidationAttachedProperties),
            new PropertyMetadata(null, OnTriggerChanged));

    [Category("Validation")]
    [Browsable(true)]
    [DisplayName("Trigger")]
    [AttachedPropertyBrowsableForType(typeof(TextBox))]
    public static BaseTrigger GetTrigger(DependencyObject element)
    {
        return (BaseTrigger)element.GetValue(TriggerProperty);
    }

    public static void SetTrigger(DependencyObject element, BaseTrigger value)
    {
        element.SetValue(TriggerProperty, value);
    }

    private static void OnTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is TextBox textBox)
        {
            BaseTrigger? existingValue = GetTrigger(textBox);
            existingValue?.Detach();
            if (e.NewValue is BaseTrigger newValue)
            {
                newValue.SetControl(textBox);
                newValue.Attach();
            }
        }
    }

}
