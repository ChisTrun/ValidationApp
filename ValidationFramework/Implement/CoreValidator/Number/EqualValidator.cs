using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Number
{
    class EqualValidator : BaseValidator
    {
        private readonly decimal _expectedValue;

        public EqualValidator(decimal expectedValue, string errorMessage = "Value does not match the expected value", string validMessage = "Value matches the expected value")
        {
            _expectedValue = expectedValue;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input && decimal.TryParse(input, out decimal value))
            {
                return value == _expectedValue;
            }
            if (obj is decimal decimalValue)
            {
                return decimalValue == _expectedValue;
            }
            if (obj is int intValue)
            {
                return intValue == _expectedValue;
            }
            return false; // Không hợp lệ nếu không phải số hoặc chuỗi
        }
    }
}
