using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Collection
{
    class CollectionSizeValidator : BaseValidator
    {
        private readonly int _minSize;
        private readonly int _maxSize;

        public CollectionSizeValidator(int minSize, int maxSize, string errorMessage = "Collection size is out of bounds", string validMessage = "Collection size is valid")
        {
            _minSize = minSize;
            _maxSize = maxSize;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is IEnumerable<object> collection)
            {
                var count = collection.Count();
                return count >= _minSize && count <= _maxSize;
            }
            return false; // Không hợp lệ nếu không phải collection
        }
    }
}
