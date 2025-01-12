using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class NoSpecialCharacterValidator : BaseValidator
    {
        public NoSpecialCharacterValidator(string errorMessage = "Input contains special characters", string validMessage = "Input does not contain special characters")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
