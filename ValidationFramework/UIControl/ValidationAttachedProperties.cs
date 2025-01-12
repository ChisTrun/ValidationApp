using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationLib.UIControl
{
    public static class ValidationAttachedProperties
    {
        /// <summary>
        /// Rules attached property
        /// </summary>
        public static readonly DependencyProperty RulesProperty =
            DependencyProperty.RegisterAttached(
                "Rules",
                typeof(List<BaseValidateRule>),
                typeof(ValidationAttachedProperties),
                new PropertyMetadata(new List<BaseValidateRule>()));

        [Category("Validation")]
        [Browsable(true)]
        [DisplayName("Rules")]
        [AttachedPropertyBrowsableForType(typeof(Control))]
        public static List<BaseValidateRule> GetRules(DependencyObject element)
        {
            return (List<BaseValidateRule>)element.GetValue(RulesProperty);
        }

        /// <summary>
        /// Observer attached property (hidden)
        /// </summary>
        public static readonly DependencyProperty ObserverProperty =
            DependencyProperty.RegisterAttached(
                "Observer",
                typeof(ValidateObserver),
                typeof(ValidationAttachedProperties),
                new PropertyMetadata(null));

        [Browsable(false)]
        public static ValidateObserver GetObserver(DependencyObject element)
        {
            // Get or create a unique instance of ValidateObserver for this control
            var observer = (ValidateObserver)element.GetValue(ObserverProperty);
            if (observer == null)
            {
                observer = new ValidateObserver();
                element.SetValue(ObserverProperty, observer);
            }

            // Update rules from the control
            observer.Rules = GetRules(element);
            return observer;
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
        [AttachedPropertyBrowsableForType(typeof(Control))]
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
            else if (d is PasswordBox passwordBox)
            {
                BaseTrigger? existingValue = GetTrigger(passwordBox);
                existingValue?.Detach();
                if (e.NewValue is BaseTrigger newValue)
                {
                    newValue.SetControl(passwordBox);
                    newValue.Attach();
                }
            }
        }
    }
}
