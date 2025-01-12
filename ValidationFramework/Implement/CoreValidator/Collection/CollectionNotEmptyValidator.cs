using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Collection
{
    class CollectionNotEmptyValidator : BaseValidator
    {
        public CollectionNotEmptyValidator(string errorMessage = "Collection cannot be empty", string validMessage = "Collection is not empty")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is IEnumerable<object> collection)
            {
                return collection.Any();
            }
            return false; // Không hợp lệ nếu không phải collection
        }
    }
}
