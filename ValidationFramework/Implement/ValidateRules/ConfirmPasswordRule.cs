using ValidationFramework.Base;
using ValidationFramework.Common;
using ValidationFramework.Implement.CoreValidator;

namespace ValidationFramework.Implement.ValidateRules
{
    public class ConfirmPasswordRule : BaseValidateRule
    {
        private string _baseValue = string.Empty;

        /// <summary>
        /// Giá trị mật khẩu chính cần so sánh
        /// </summary>
        public string BaseValue
        {
            get => _baseValue;
            set
            {
                _baseValue = value;
                UpdateValidator();
            }
        }

        public ConfirmPasswordRule()
        {
            UpdateValidator(); // Khởi tạo validator ban đầu
        }

        protected override void UpdateValidator()
        {
            var builder = new ValidateBuilder();
            builder.AddBaseValidator(new EqualValidator(
                baseValue: BaseValue,
                errorMessage: _errorMessage ?? "Confirm password must be equal with password",
                validMessage: _validMessage ?? "Confirm password is valid"
            ));
            this._validator = builder.Build();
        }

        public override List<ValidateRecord> Validate(object obj)
        {
            if (_validator == null)
            {
                return new List<ValidateRecord>();
            }

            return this._validator.Validate(obj);
        }
    }
}
