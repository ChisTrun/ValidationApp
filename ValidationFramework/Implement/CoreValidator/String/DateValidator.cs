using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class DateValidator : BaseValidator
    {
        private readonly string _dateFormat;
        public DateValidator(string dateFormat = "dd/MM/yyyy", string errorMessage = "Input is not a valid date", string validMessage = "Input is a valid date")
        {
            _dateFormat = dateFormat; // Định dạng ngày tháng cần kiểm tra
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return DateTime.TryParseExact(input, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
