using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class LowercaseValidator : BaseValidator
    {
        public LowercaseValidator(string errorMessage = "Input is not fully lowercase", string validMessage = "Input is fully lowercase")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.All(char.IsLower);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
