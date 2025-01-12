using System.Collections.Generic;
using System.ComponentModel;
using ValidationFramework.Base;

namespace ValidationFramework.Common
{
    public class ValidateObserver
    {
        public List<BaseValidateRule> Rules { get; set; } = new List<BaseValidateRule>();

        public BaseValidationResultRenderer? Renderer { get; set; }

        public void Validate(object content)
        {
            List<ValidateRecord> summary = new List<ValidateRecord>();
            foreach (var rule in Rules)
            {
                summary.AddRange(rule.Validate(content));
            }

            Renderer?.RenderResult(summary);
        }
    }
}
