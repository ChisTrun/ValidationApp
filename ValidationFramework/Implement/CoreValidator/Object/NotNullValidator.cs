using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Object
{
    class NotNullValidator : BaseValidator
    {
        public NotNullValidator(string errorMessage = "Object cannot be null", string validMessage = "Object is valid")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        // Logic kiểm tra hợp lệ
        protected override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
