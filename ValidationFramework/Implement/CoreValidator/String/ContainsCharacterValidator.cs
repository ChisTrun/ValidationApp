using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.String
{
    class ContainsCharacterValidator : BaseValidator
    {
        private readonly char _character;

        public ContainsCharacterValidator(char character, string errorMessage = "Input does not contain the required character", string validMessage = "Input contains the required character")
        {
            _character = character;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input)
            {
                return input.Contains(_character);
            }
            return false; // Không hợp lệ nếu không phải chuỗi
        }
    }
}
