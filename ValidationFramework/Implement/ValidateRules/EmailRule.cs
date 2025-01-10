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

    public class EmailRule : BaseValidateRule
    {

        public EmailRule()
        {
            var builder = new ValidateBuilder();
            builder.AddRegexValidator(new RegexValidator(pattern: @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"));
            builder.AddStringLengthValidator(new StringLengthValidator(minLength: 6, maxLength: 100));  
            this._validator = builder.Build();
        }
        public override  List<ValidateRecord> Validate(object obj)
        {
            if (_validator == null)
            {
                return new List<ValidateRecord>();
            }

            return this._validator.Validate(obj);
        }
    }
}
