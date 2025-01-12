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
    public class RequireFieldRule : BaseValidateRule
    {

        public RequireFieldRule()
        {
            UpdateValidator();
        }

        protected override void UpdateValidator()
        {
            var builder = new ValidateBuilder();
            builder.AddBaseValidator(new NotNullValidator(_errorMessage ?? "This field is required", validMessage: ""));
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
