using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class MaxLengthValidator : BaseValidator
    {
        private readonly int _maxLength;

        public MaxLengthValidator(int maxLength, string errorMessage = "Input exceeds the maximum length", string validMessage = "Input meets the maximum length requirement")
        {
            _maxLength = maxLength;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.Length <= _maxLength;
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
