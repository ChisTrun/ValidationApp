using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationFramework.Implement.CoreValidator
{
    public class RegexValidator : BaseValidator
    {
        private readonly string _pattern;

        public RegexValidator(string pattern, string errorMessage = "Input does not match the pattern", string validMessage = "Input is valid")
        {
            _pattern = pattern;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        public override List<ValidateRecord> Validate(object obj)
        {
            var validateRecord = new ValidateRecord();
            if (obj is string input && Regex.IsMatch(input, _pattern))
            {
                validateRecord.IsValid = true;
                validateRecord.Message = _validMessage;
            }
            else
            {
                validateRecord.IsValid = false;
                validateRecord.Message = _errorMessage;
            }

            if (_nextValidator != null)
            {
                var nextValidateRecords = _nextValidator.Validate(obj);
                nextValidateRecords.Add(validateRecord);
                return nextValidateRecords;
            }

            return new List<ValidateRecord> { validateRecord };
        }
    }
}
