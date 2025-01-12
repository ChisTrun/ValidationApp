using System;
using System.Collections.Generic;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationFramework.Implement.CoreValidator
{
    public class DateRangedValidator : BaseValidator
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public DateRangedValidator(DateTime minDate, DateTime maxDate, string errorMessage = "Date is out of valid range")
        {
            _minDate = minDate;
            _maxDate = maxDate;
            _errorMessage = errorMessage;
        }

        public override List<ValidateRecord> Validate(object obj)
        {
            var validateRecord = new ValidateRecord();
            if (obj is DateTime date)
            {
                if (date < _minDate || date > _maxDate)
                {
                    validateRecord.IsValid = false;
                    validateRecord.Message = $"Date must be between {_minDate.ToShortDateString()} and {_maxDate.ToShortDateString()}.";
                }
                else
                {
                    validateRecord.IsValid = true;
                    validateRecord.Message = "Date is valid.";
                }
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
