using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFramework.Base;
using ValidationFramework.Common;
using ValidationFramework.Implement.CoreValidator;

namespace ValidationFramework.Implement.ValidateRules
{

    public class ConfirmPasswordRule : BaseValidateRule
    {
        public required string baseValue { get; set; }
        public ConfirmPasswordRule()
        {
            var builder = new ValidateBuilder();
            builder.AddBaseValidator(new EqualValidator(baseValue: baseValue ?? string.Empty, errorMessage: "Confirm Password must be equal with Password", validMessage: "Confirm Password is Valid"));
            this._validator = builder.Build();
        }
        public override List<ValidateRecord> Validate(object obj)
        {
            if (_validator == null)
            {
                return new List<ValidateRecord>();
            }

            return this._validator.Validate(obj);
        }
    }
}
