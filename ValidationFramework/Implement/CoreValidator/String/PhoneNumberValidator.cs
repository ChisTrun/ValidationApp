using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class PhoneNumberValidator : BaseValidator
    {
        public PhoneNumberValidator(string errorMessage = "Input is not a valid phone number", string validMessage = "Input is a valid phone number")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                var phoneRegex = @"^\+?[0-9]{1,4}?\s?[0-9]{7,15}$"; // Số điện thoại có thể bắt đầu bằng dấu `+`
                return Regex.IsMatch(input, phoneRegex);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
