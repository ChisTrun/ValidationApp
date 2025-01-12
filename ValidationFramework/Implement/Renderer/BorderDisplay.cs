﻿using System.Collections.Generic;
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
                control.BorderBrush = Brushes.Green;
                control.BorderThickness = new System.Windows.Thickness(3);
                control.ToolTip = message;
            }
            else
            {
                control.BorderBrush = Brushes.Red;
                control.BorderThickness = new System.Windows.Thickness(3);
                control.ToolTip = message;
            }
        }
    }
}
