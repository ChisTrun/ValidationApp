using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class StartWithValidator : BaseValidator
    {
        private readonly string _startWith;

        public StartWithValidator(string startWith, string errorMessage = "Input does not start with the required character(s)", string validMessage = "Input starts with the required character(s)")
        {
            _startWith = startWith;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.StartsWith(_startWith);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
