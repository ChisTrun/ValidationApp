using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Number
{
    class RangeValidator
    {
        private readonly decimal _min;
        private readonly decimal _max;

        public RangeValidator(decimal min, decimal max, string errorMessage = "Value is out of range", string validMessage = "Value is within the valid range")
        {
            _min = min;
            _max = max;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input && decimal.TryParse(input, out decimal value))
            {
                return value >= _min && value <= _max;
            }
            if (obj is decimal decimalValue)
            {
                return decimalValue >= _min && decimalValue <= _max;
            }
            if (obj is int intValue)
            {
                return intValue >= _min && intValue <= _max;
            }
            return false; // Không hợp lệ nếu không phải chuỗi hoặc số
        }
    }
}
