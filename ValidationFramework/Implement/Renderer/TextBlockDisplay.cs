
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
        foreach (var record in summary)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = record.Message,
                Foreground = Brushes.Red
            };
            stackPanel.Children.Add(textBlock);
        }
        if (this._validationHelper != null)
        {
            this._validationHelper.Content = stackPanel;
        }
    }
}
