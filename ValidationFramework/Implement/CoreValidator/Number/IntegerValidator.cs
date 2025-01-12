using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Number
{
    class IntegerValidator : BaseValidator
    {
        public IntegerValidator(string errorMessage = "Value must be an integer", string validMessage = "Value is a valid integer")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return int.TryParse(input, out _); // Hợp lệ nếu chuỗi chuyển đổi thành số nguyên
            }
            if (obj is int)
            {
                return true; // Hợp lệ nếu là số nguyên
            }
            return false; // Không hợp lệ nếu không phải chuỗi hoặc số nguyên
        }
    }
}
