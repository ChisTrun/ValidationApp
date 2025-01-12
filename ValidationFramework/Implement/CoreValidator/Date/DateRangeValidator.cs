using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Date
{
    class DateRangeValidator : BaseValidator
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public DateRangeValidator(DateTime startDate, DateTime endDate, string errorMessage = "Date is out of the allowed range", string validMessage = "Date is within the allowed range")
        {
            _startDate = startDate;
            _endDate = endDate;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input && DateTime.TryParse(input, out DateTime date))
            {
                return date >= _startDate && date <= _endDate;
            }
            return false; // Không hợp lệ nếu không phải chuỗi ngày
        }
    }
}
