using System.Collections.Generic;
using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationFramework.Implement.CoreValidator
{
    public class NotNullValidator : BaseValidator
    {

        public NotNullValidator(string errorMessage = "Object cannot be null", string validMessage = "Object is valid")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        public override List<ValidateRecord> Validate(object obj)
        {
            var validateRecord = new ValidateRecord
            {
                IsValid = obj != null,
                Message = obj != null ? _validMessage : _errorMessage
            };

            if (_nextValidator != null)
            {
                var nextValidateRecords = _nextValidator.Validate(obj);
                nextValidateRecords.Add(validateRecord);
                return nextValidateRecords;
            }

            return new List<ValidateRecord> { validateRecord };
        }
    }
}
