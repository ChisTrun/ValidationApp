using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFramework.Base;

namespace ValidationFramework.Common
{
    public class ValidateObserver
    {
        public List<IValidateRule> Rules { get; set; } = [];
        public BaseValidationResultRenderer? Renderer { get; set; }

        public void Validate(string content)
        {
            List<ValidateRecord> summary = new List<ValidateRecord>();
            foreach (var rule in Rules)
            {
                summary.AddRange(rule.Validate(content));
            }
            if (Renderer != null) {
                Renderer.RenderResult(summary);
            }
        }
    }
}
