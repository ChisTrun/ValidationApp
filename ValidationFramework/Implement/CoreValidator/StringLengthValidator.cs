using System;
using System.Collections.Generic;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationFramework.Implement.CoreValidator
{
    public class StringLengthValidator : BaseValidator
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public StringLengthValidator(int minLength, int maxLength, string errorMessage = "Input length is out of bounds", string validMessage = "Input length is valid")
        {
            _minLength = minLength;
            _maxLength = maxLength;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        public override List<ValidateRecord> Validate(object obj)
        {
            var validateRecord = new ValidateRecord();
            if (obj is string input && input.Length >= _minLength && input.Length <= _maxLength)
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
