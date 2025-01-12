using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationLib.UIControl
{
    public class ValidationHelper : ContentControl
    {
        /// <summary>
        /// Target attached property
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
            if (d is ValidationHelper helper)
            {
                if (e.OldValue is Control oldControl &&
                    oldControl.GetValue(ValidationAttachedProperties.ObserverProperty) is ValidateObserver oldObserver)
                {
                    oldObserver.Renderer = null;
                }

                if (e.NewValue is Control newControl &&
                    newControl.GetValue(ValidationAttachedProperties.ObserverProperty) is ValidateObserver newObserver)
                {
                    newObserver.Renderer = helper.Renderer;
                }
            }
        }

        /// <summary>
        /// Renderer attached property
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
                    if (helper.Target?.GetValue(ValidationAttachedProperties.ObserverProperty) is ValidateObserver oldObserver)
                    {
                        oldObserver.Renderer = null;
                    }
                }

                if (e.NewValue is BaseValidationResultRenderer newRenderer)
                {
                    newRenderer.AddValidationHelper(helper);
                    if (helper.Target?.GetValue(ValidationAttachedProperties.ObserverProperty) is ValidateObserver newObserver)
                    {
                        newObserver.Renderer = newRenderer;
                    }
                }
            }
        }
    }
}
