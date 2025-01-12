using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFramework.Common;

namespace ValidationFramework.Base
{
    public abstract class BaseValidator : IValidator
    {

        protected  string? _errorMessage;
        protected  string? _validMessage;
        protected IValidator? _nextValidator { get; set; }

        public void SetNextValidator(IValidator nextValidator)
        {
            _nextValidator = nextValidator;
        }
        //public abstract List<ValidateRecord> Validate(object obj);
        // Template Method
        public virtual List<ValidateRecord> Validate(object obj)
        {
            // Gọi phương thức IsValid để kiểm tra hợp lệ
            var isValid = IsValid(obj);
            var validateRecord = new ValidateRecord
            {
                IsValid = isValid,
                Message = isValid ? _validMessage : _errorMessage
            };

            // Gọi validator tiếp theo nếu có
            if (_nextValidator != null)
            {
                var nextValidateRecords = _nextValidator.Validate(obj);
                nextValidateRecords.Add(validateRecord);
                return nextValidateRecords;
            }

            // Trả về kết quả
            return new List<ValidateRecord> { validateRecord };
        }

        // Phương thức trừu tượng để lớp con triển khai logic cụ thể
        protected abstract bool IsValid(object obj);
    }
}
