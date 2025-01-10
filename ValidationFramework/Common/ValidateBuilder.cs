using System;
using ValidationFramework.Base;
using ValidationFramework.Implement.CoreValidator;

namespace ValidationFramework.Common
{
    public class ValidateBuilder
    {
        private BaseValidator? _validator;

        public ValidateBuilder() { }

        public void AddRegexValidator(RegexValidator validator)
        {
            if (_validator == null)
            {
                _validator = validator;
            }
            else
            {
                _validator.SetNextValidator(validator);
            }
        }

        public void AddStringLengthValidator(StringLengthValidator validator)
        {
            if (_validator == null)
            {
                _validator = validator;
            }
            else
            {
                _validator.SetNextValidator(validator);
            }
        }

        public BaseValidator? Build()
        {
            BaseValidator? builtValidator = _validator;
            _validator = null;
            return builtValidator;
        }
    }
}
