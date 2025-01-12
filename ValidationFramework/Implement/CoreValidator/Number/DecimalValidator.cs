using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Number
{
    class DecimalValidator : BaseValidator
    {
        public DecimalValidator(string errorMessage = "Value must be a decimal", string validMessage = "Value is a valid decimal")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return decimal.TryParse(input, out _); // Hợp lệ nếu chuỗi chuyển đổi thành số thập phân
            }
            if (obj is decimal)
            {
                return true; // Hợp lệ nếu là số thập phân
            }
            return false; // Không hợp lệ nếu không phải chuỗi hoặc số thập phân
        }
    }
}
