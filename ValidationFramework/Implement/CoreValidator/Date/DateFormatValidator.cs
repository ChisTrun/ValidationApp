using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Date
{
    class DateFormatValidator : BaseValidator
    {
        private readonly string _dateFormat;

        public DateFormatValidator(string dateFormat = "yyyy-MM-dd", string errorMessage = "Invalid date format", string validMessage = "Date format is valid")
        {
            _dateFormat = dateFormat;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return DateTime.TryParseExact(input, _dateFormat, null, System.Globalization.DateTimeStyles.None, out _);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
