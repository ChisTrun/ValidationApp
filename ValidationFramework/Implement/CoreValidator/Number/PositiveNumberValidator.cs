﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Number
{
    class PositiveNumberValidator : BaseValidator
    {
        public PositiveNumberValidator(string errorMessage = "Value must be a positive number", string validMessage = "Value is a positive number")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input && decimal.TryParse(input, out decimal value))
            {
                return value > 0;
            }
            if (obj is decimal decimalValue)
            {
                return decimalValue > 0;
            }
            if (obj is int intValue)
            {
                return intValue > 0;
            }
            return false; // Không hợp lệ nếu không phải số hoặc chuỗi
        }
    }
}
