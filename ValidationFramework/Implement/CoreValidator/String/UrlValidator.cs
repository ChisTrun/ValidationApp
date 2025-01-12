using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class UrlValidator : BaseValidator
    {
        public UrlValidator(string errorMessage = "Input is not a valid URL", string validMessage = "Input is a valid URL")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                var urlRegex = @"^(http|https):\/\/[^\s$.?#].[^\s]*$";
                return Regex.IsMatch(input, urlRegex);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
