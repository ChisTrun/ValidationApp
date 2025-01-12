using System;
using System.Collections.Generic;
using ValidationFramework.Base;
using ValidationFramework.Common;
using ValidationFramework.Implement.CoreValidator;

namespace ValidationFramework.Implement.ValidateRules
{
    public class EmailRule : BaseValidateRule
    {
        private int _minLength = 6;
        private int _maxLength = 100;
        private string _regexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public int MinLength
        {
            get => _minLength;
            set
            {
                _minLength = value;
                UpdateValidator();
            }
        }

        public int MaxLength
        {
            get => _maxLength;
            set
            {
                _maxLength = value;
                UpdateValidator();
            }
        }

        public string RegexPattern
        {
            get => _regexPattern;
            set
            {
                _regexPattern = value;
                UpdateValidator();
            }
        }

        public EmailRule()
        {
            UpdateValidator();
        }

        protected override void UpdateValidator()
        {
            var builder = new ValidateBuilder();
            builder.AddBaseValidator(new RegexValidator(_regexPattern, errorMessage: _errorMessage ?? "Invalid Email", _validMessage ?? "Valid Email"));
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
