using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class RegexValidator : BaseValidator
    {
        private readonly Regex _regex;

        public RegexValidator(string pattern, string errorMessage = "Input does not match the required pattern", string validMessage = "Input matches the pattern")
        {
            _regex = new Regex(pattern);
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return _regex.IsMatch(input);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
