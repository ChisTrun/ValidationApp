using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class NotEmptyOrWhitespaceValidator : BaseValidator
    {
        public NotEmptyOrWhitespaceValidator(string errorMessage = "Input cannot be empty or whitespace", string validMessage = "Input is not empty or whitespace")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return !string.IsNullOrWhiteSpace(input);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
