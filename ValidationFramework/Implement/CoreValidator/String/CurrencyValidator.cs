using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class CurrencyValidator : BaseValidator
    {
        public CurrencyValidator(string errorMessage = "Input is not a valid currency", string validMessage = "Input is a valid currency")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                var currencyRegex = @"^\p{Sc}?\s?\d+(\.\d{1,2})?$"; // Hỗ trợ ký hiệu tiền tệ
                return Regex.IsMatch(input, currencyRegex);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
