using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFramework.Base;
using ValidationFramework.Common;
using ValidationFramework.Implement.CoreValidator;

namespace ValidationFramework.Implement.ValidateRules
{
        public class PasswordRule : BaseValidateRule
        {
            private int _minLength = 8;
            private int _maxLength = 20;
            private string _regexPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$";

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

            public PasswordRule()
            {
                UpdateValidator();
            }

            protected override void UpdateValidator()
            {
                var builder = new ValidateBuilder();
                builder.AddBaseValidator(new RegexValidator(_regexPattern, _errorMessage ?? "The password must contain at least one letter, at least one digit, and consist only of letters and digits.", _validMessage ?? "Valid password"));
                builder.AddBaseValidator(new StringLengthValidator(_minLength, _maxLength, errorMessage: $"Password atleast {_minLength} letters", validMessage: ""));
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
