using System;
using ValidationFramework.Base;
using ValidationFramework.Implement.CoreValidator;

namespace ValidationFramework.Common
{
    public class ValidateBuilder
    {
        private BaseValidator? _validator;
        private BaseValidator? _lastValidator; // Lưu validator cuối cùng

        public ValidateBuilder() { }

        public void AddValidator(BaseValidator validator)
        {
            if (_validator == null)
            {
                _validator = validator;
                _lastValidator = validator; // Nếu là validator đầu tiên, gán cho cả hai
            }
            else
            {
                _lastValidator?.SetNextValidator(validator); // Thêm vào cuối chuỗi
                _lastValidator = validator; // Cập nhật validator cuối cùng
            }
        }
        public void AddRegexValidator(RegexValidator validator)
        {
            if (_validator == null)
            {
                _validator = validator;
            }
            else
            {
                _validator.SetNextValidator(validator);
            }
        }

        public void AddStringLengthValidator(StringLengthValidator validator)
        {
            if (_validator == null)
            {
                _validator = validator;
            }
            else
            {
                _validator.SetNextValidator(validator);
            }
        }

        public void AddDateRangedValidator(DateRangedValidator validator)
        {
            if (_validator == null)
            {
                _validator = validator;
            }
            else
            {
                _validator.SetNextValidator(validator);
            }
        }   

        public BaseValidator? Build()
        {
            BaseValidator? builtValidator = _validator;
            _validator = null;
            return builtValidator;
        }
    }
}
