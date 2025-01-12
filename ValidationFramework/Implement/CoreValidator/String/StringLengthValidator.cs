using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class StringLengthValidator : BaseValidator
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public StringLengthValidator(int minLength, int maxLength, string errorMessage = "Input length is out of bounds", string validMessage = "Input length is valid")
        {
            _minLength = minLength;
            _maxLength = maxLength;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        // Logic kiểm tra hợp lệ
        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.Length >= _minLength && input.Length <= _maxLength;
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
