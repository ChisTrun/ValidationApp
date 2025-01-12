using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class NumericValidator : BaseValidator
    {
        public NumericValidator(string errorMessage = "Input must only contain numeric characters", string validMessage = "Input is numeric")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }
        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.All(char.IsDigit);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
