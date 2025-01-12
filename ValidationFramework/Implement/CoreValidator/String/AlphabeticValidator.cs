using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class AlphabeticValidator : BaseValidator
    {
        public AlphabeticValidator(string errorMessage = "Input must only contain alphabetic characters", string validMessage = "Input is alphabetic")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.All(char.IsLetter);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
