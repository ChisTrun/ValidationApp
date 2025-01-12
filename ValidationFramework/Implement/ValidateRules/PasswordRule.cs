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
    public class PasswordRule : BaseValidateRule
    {

        public PasswordRule()
        {
            var builder = new ValidateBuilder();

            builder.AddRegexValidator(new RegexValidator(pattern: @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$"));

            builder.AddStringLengthValidator(new StringLengthValidator(minLength: 8, maxLength: 20));

            this._validator = builder.Build();
        }

        public  override List<ValidateRecord> Validate(object obj)
        {
            if (_validator == null)
            {
                return new List<ValidateRecord>();
            }

            return this._validator.Validate(obj);
        }
    }
}
