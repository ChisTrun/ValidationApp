using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Collection
{
    class CollectionSubsetValidator : BaseValidator
    {
        private readonly IEnumerable<object> _subset;
        public CollectionSubsetValidator(IEnumerable<object> subset, string errorMessage = "Collection does not contain the required subset", string validMessage = "Collection contains the required subset")
        {
            _subset = subset;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is IEnumerable<object> collection)
            {
                return !_subset.Except(collection).Any();
            }
            return false; // Không hợp lệ nếu không phải collection
        }
    }
}
