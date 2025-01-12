using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Collection
{
    class CollectionContainsValidator : BaseValidator
    {
        private readonly object _value;

        public CollectionContainsValidator(object value, string errorMessage = "Collection does not contain the required value", string validMessage = "Collection contains the required value")
        {
            _value = value;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is IEnumerable<object> collection)
            {
                return collection.Contains(_value);
            }
            return false; // Không hợp lệ nếu không phải collection
        }
    }
}
