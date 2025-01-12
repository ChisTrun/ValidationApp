using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class IntegerValidator : BaseValidator
    {
        public IntegerValidator(string errorMessage = "Input is not a valid integer", string validMessage = "Input is a valid integer")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return int.TryParse(input, out _);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
