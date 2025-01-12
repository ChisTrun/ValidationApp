using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Collection
{
    class CollectionUniqueValidator : BaseValidator
    {
        public CollectionUniqueValidator(string errorMessage = "Collection contains duplicate elements", string validMessage = "Collection elements are unique")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }
        protected override bool IsValid(object obj)
        {
            if (obj is IEnumerable<object> collection)
            {
                return collection.Distinct().Count() == collection.Count();
            }
            return false; // Không hợp lệ nếu không phải collection
        }
    }
}
