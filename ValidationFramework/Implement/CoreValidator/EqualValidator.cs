using ValidationFramework.Base;
using ValidationFramework.Common;

namespace ValidationFramework.Implement.CoreValidator
{
    public class EqualValidator : BaseValidator
    {
        private readonly string _baseValue;

        public EqualValidator(string baseValue, string errorMessage = "Input length is out of bounds", string validMessage = "Input length is valid")
        {
            _baseValue = baseValue;
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        public override List<ValidateRecord> Validate(object obj)
        {
            var validateRecord = new ValidateRecord();
            if (obj is string input && input.Equals(_baseValue))
            {
                validateRecord.IsValid = true;
                validateRecord.Message = _validMessage;
            }
            else
            {
                validateRecord.IsValid = false;
                validateRecord.Message = _errorMessage;
            }

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
