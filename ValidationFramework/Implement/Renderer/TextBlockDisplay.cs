
using System.Windows.Controls;
using System.Windows.Media;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationLib.Display;

public class TextBlockDisplay : BaseValidationResultRenderer
{
	
    public override void RenderResult(List<ValidateRecord> summary)
    {
        StackPanel stackPanel = new StackPanel();
        bool hasError = false;
        foreach (var record in summary)
        {
            if (record.IsValid)
            {
                continue;
            }
            else
            {
                hasError = true;
            }
            TextBlock textBlock = new TextBlock
            {
                Text = record.Message,
                Foreground = Brushes.Red
            };
            stackPanel.Children.Add(textBlock);
        }
        if (!hasError)
        {
            stackPanel.Children.Clear();
            if (_validationHelper?.Target is Control control)
            {
                control.BorderBrush = Brushes.Green;
                control.BorderThickness = new System.Windows.Thickness(3);
            }    
        }
        if (this._validationHelper != null)
        {
            this._validationHelper.Content = stackPanel;
        }
    }
}
