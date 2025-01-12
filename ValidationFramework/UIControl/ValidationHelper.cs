using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationLib.UIControl;

public class ValidationHelper : ContentControl
{
    /// <summary>
    /// Source attached property
    /// </summary>
    public static readonly DependencyProperty TargetProperty =
        DependencyProperty.Register(
            nameof(Target),
            typeof(Control),
            typeof(ValidationHelper),
            new PropertyMetadata(null, OnTargetChanged));

    [Category("Validation")]
    [Browsable(true)]
    public Control Target
    {
        get => (Control)GetValue(TargetProperty);
        set => SetValue(TargetProperty, value);
    }

    private static void OnTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ValidationHelper helper && helper.Renderer != null)
        {
            if (e.OldValue is Control oldControl)
            {
                if (oldControl.GetValue(UIControl.ValidationAttachedProperties.ObserverProperty) is ValidateObserver observer)
                {
                    observer.Renderer = null;

                }
            }
            if (e.NewValue is Control newControl)
            {
                if (newControl.GetValue(UIControl.ValidationAttachedProperties.ObserverProperty) is ValidateObserver observer)
                {
                    observer.Renderer = helper.Renderer;

                }
            }
        }
    }

    /// <summary>
    /// Display attached property
    /// </summary>
    public static readonly DependencyProperty RendererProperty =
        DependencyProperty.Register(
            nameof(Renderer),
            typeof(BaseValidationResultRenderer),
            typeof(ValidationHelper),
            new PropertyMetadata(null, OnRendererChanged));

    [Category("Validation")]
    [Browsable(true)]
    public BaseValidationResultRenderer Renderer
    {
        get => (BaseValidationResultRenderer)GetValue(RendererProperty);
        set => SetValue(RendererProperty, value);
    }

    private static void OnRendererChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ValidationHelper helper)
        {
            if (e.OldValue is BaseValidationResultRenderer oldRenderer)
            {
                oldRenderer.RemoveValidationHelper();
                if (helper.Target?.GetValue(UIControl.ValidationAttachedProperties.ObserverProperty) is ValidateObserver observer)
                {
                    observer.Renderer = null;
                }
            }
            if (e.NewValue is BaseValidationResultRenderer newRender)
            {
                newRender.AddValidationHelper(helper);
                if (helper.Target?.GetValue(UIControl.ValidationAttachedProperties.ObserverProperty) is ValidateObserver observer)
                {
                    observer.Renderer = newRender;
                }
            }
        }
    }
}

