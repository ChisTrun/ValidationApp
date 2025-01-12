using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Collection
{
    class CollectionAllMatchValidator : BaseValidator
    {
        private readonly Func<object, bool> _predicate;

        public CollectionAllMatchValidator(Func<object, bool> predicate, string errorMessage = "Not all elements match the condition", string validMessage = "All elements match the condition")
        {
            _predicate = predicate;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is IEnumerable<object> collection)
            {
                return collection.All(_predicate);
            }
            return false; // Không hợp lệ nếu không phải collection
        }
    }
}
