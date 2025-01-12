using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationLib.Display;

public class ColorDisplay : BaseValidationResultRenderer
{
    public override void RenderResult(List<ValidateRecord> summary)
    {
        if (_validationHelper?.Target is Control control)
        {
            bool isValid = true;
            string message = "Object is Valid";
            foreach (var record in summary)
            {
                if (record.IsValid)
                {
                    continue;
                }
                else
                {
                    isValid = false;
                    message = record.Message ?? "Unknown error";
                    break;
                }
            }
            if (isValid)
            {
                control.Background = Brushes.Green;
            }
            else
            {
                control.Background = Brushes.Red;
            }
        }
    }
}
