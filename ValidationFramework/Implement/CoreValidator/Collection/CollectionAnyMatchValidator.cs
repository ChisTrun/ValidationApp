using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Collection
{
    class CollectionAnyMatchValidator : BaseValidator
    {
        private readonly Func<object, bool> _predicate;

        public CollectionAnyMatchValidator(Func<object, bool> predicate, string errorMessage = "No elements match the condition", string validMessage = "At least one element matches the condition")
        {
            _predicate = predicate;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is IEnumerable<object> collection)
            {
                return collection.Any(_predicate);
            }
            return false; // Không hợp lệ nếu không phải collection
        }
    }
}
