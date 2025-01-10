﻿using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationLib.UIControl;

public static class ValidationAttachedProperties
{
	/// <summary>
	/// Rules attached property
	/// </summary>
	public static readonly DependencyProperty RulesProperty =
		DependencyProperty.RegisterAttached(
			"Rules",
			typeof(List<IValidateRule>),
			typeof(ValidationAttachedProperties),
			new PropertyMetadata(new List<IValidateRule>()));

	[Category("Validation")]
	[Browsable(true)]
	[DisplayName("Rules")]
	[AttachedPropertyBrowsableForType(typeof(TextBox))]
	public static List<IValidateRule> GetRules(DependencyObject element)
	{
		return (List<IValidateRule>)element.GetValue(RulesProperty);
	}


	/// <summary>
	/// Handler attached property (hidden)
	/// </summary>
	public static readonly DependencyProperty ObserverProperty =
		DependencyProperty.RegisterAttached(
			"Observer",
			typeof(ValidateObserver),
			typeof(ValidationAttachedProperties),
			new PropertyMetadata(new ValidateObserver()));

	[Browsable(false)]
    public static ValidateObserver GetObserver(DependencyObject element)
	{
		var handler = (ValidateObserver)element.GetValue(ObserverProperty);
		var rules = GetRules(element);
		handler.Rules = rules;
		return (ValidateObserver)element.GetValue(ObserverProperty);
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
                newValue.SetTextBox(textBox);
                newValue.Attach();
            }
        }
    }

}