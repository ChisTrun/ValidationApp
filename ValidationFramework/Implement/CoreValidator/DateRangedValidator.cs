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

        public DateRangedValidator(DateTime minDate, DateTime maxDate, string errorMessage = "Date is out of valid range", string validMessage = "Date is valid")
        {
            _minDate = minDate;
            _maxDate = maxDate;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        public override List<ValidateRecord> Validate(object obj)
        {
            var validateRecord = new ValidateRecord();
            if (obj is string dateString)
            {
                // Thử chuyển đổi chuỗi sang kiểu DateTime
                if (DateTime.TryParse(dateString, out DateTime date))
                {
                    // Kiểm tra xem ngày có nằm trong khoảng hợp lệ hay không
                    if (date < _minDate || date > _maxDate)
                    {
                        validateRecord.IsValid = false;
                        validateRecord.Message = _errorMessage;
                    }
                    else
                    {
                        validateRecord.IsValid = true;
                        validateRecord.Message = _validMessage;
                    }
                }
                else
                {
                    // Nếu chuyển đổi không thành công
                    validateRecord.IsValid = false;
                    validateRecord.Message = "Invalid date format.";
                }
            }
            else
            {
                // Nếu obj không phải là chuỗi
                validateRecord.IsValid = false;
                validateRecord.Message = "Input is not a valid string.";
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
