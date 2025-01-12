using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Date
{
    class SpecificDayValidator : BaseValidator
    {
        private readonly DayOfWeek _dayOfWeek;

        public SpecificDayValidator(DayOfWeek dayOfWeek, string errorMessage = "Date is not the specified day", string validMessage = "Date matches the specified day")
        {
            _dayOfWeek = dayOfWeek;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input && DateTime.TryParse(input, out DateTime date))
            {
                return date.DayOfWeek == _dayOfWeek;
            }
            return false; // Không hợp lệ nếu không phải chuỗi ngày
        }
    }
}
