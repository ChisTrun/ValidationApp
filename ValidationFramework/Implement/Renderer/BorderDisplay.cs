using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationLib.Display;

public class BorderDisplay : BaseValidationResultRenderer
{
    public override void RenderResult(List<ValidateRecord> summary)
    {
        if (_validationHelper?.Target is Control control)
        {
            if (summary.Count > 0)
            {
                control.BorderBrush = Brushes.Red;
                control.ToolTip = string.Join("\n", summary.Select(r => r.Message));
            }
            else
            {
                control.BorderBrush = Brushes.Gray;
                control.ToolTip = null;
            }
        }
    }
}
