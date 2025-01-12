using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Object
{
    class PropertyRequiredValidator : BaseValidator
    {
        private readonly string _propertyName;

        public PropertyRequiredValidator(string propertyName, string errorMessage = "Property is required", string validMessage = "Property is valid")
        {
            _propertyName = propertyName;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj == null)
                return false;

            var property = obj.GetType().GetProperty(_propertyName);
            if (property == null)
                return false; // Không tìm thấy thuộc tính => Không hợp lệ

            var value = property.GetValue(obj);
            return value != null; // Hợp lệ nếu thuộc tính không phải null
        }
    }
}
