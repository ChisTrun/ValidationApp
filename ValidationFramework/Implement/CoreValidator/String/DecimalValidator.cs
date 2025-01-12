using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class DecimalValidator : BaseValidator
    {
        public DecimalValidator(string errorMessage = "Input is not a valid decimal number", string validMessage = "Input is a valid decimal number")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return decimal.TryParse(input, out _);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
