using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class NoLeadingOrTrailingWhitespaceValidator : BaseValidator
    {
        public NoLeadingOrTrailingWhitespaceValidator(string errorMessage = "Input has leading or trailing whitespace", string validMessage = "Input has no leading or trailing whitespace")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input == input.Trim();
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
