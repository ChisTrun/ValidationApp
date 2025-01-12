using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class EmailValidator : BaseValidator
    {
        public EmailValidator(string errorMessage = "Input is not a valid email address", string validMessage = "Input is a valid email address")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }
        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(input, emailRegex);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
