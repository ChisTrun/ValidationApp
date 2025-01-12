﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Number
{
    class LessThanValidator : BaseValidator
    {
        private readonly decimal _threshold;

        public LessThanValidator(decimal threshold, string errorMessage = "Value must be less than the threshold", string validMessage = "Value is less than the threshold")
        {
            _threshold = threshold;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input && decimal.TryParse(input, out decimal value))
            {
                return value < _threshold;
            }
            if (obj is decimal decimalValue)
            {
                return decimalValue < _threshold;
            }
            if (obj is int intValue)
            {
                return intValue < _threshold;
            }
            return false; // Không hợp lệ nếu không phải số hoặc chuỗi
        }
    }
}
