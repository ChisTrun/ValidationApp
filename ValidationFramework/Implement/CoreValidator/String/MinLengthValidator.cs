using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class MinLengthValidator : BaseValidator
    {
        private readonly int _minLength;

        public MinLengthValidator(int minLength, string errorMessage = "Input is shorter than the minimum length", string validMessage = "Input meets the minimum length requirement")
        {
            _minLength = minLength;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.Length >= _minLength;
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
