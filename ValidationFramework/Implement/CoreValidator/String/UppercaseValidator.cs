using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class UppercaseValidator : BaseValidator
    {
        public UppercaseValidator(string errorMessage = "Input is not fully uppercase", string validMessage = "Input is fully uppercase")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.All(char.IsUpper);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
