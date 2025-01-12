using System;
using System.Collections.Generic;
using System.ComponentModel;
using ValidationFramework.Base;
using ValidationFramework.Common;
using ValidationFramework.Implement.CoreValidator;

namespace ValidationFramework.Implement.ValidateRules
{
    public class DateRule : BaseValidateRule
    {
        private string _minDate = "01-01-2024";
        private string _maxDate = "01-01-2025";

        public string MinDate
        {
            get => _minDate;
            set
            {
                _minDate = value;
                UpdateValidator(); // Cập nhật validator mỗi khi giá trị thay đổi
            }
        }

        public string MaxDate
        {
            get => _maxDate;
            set
            {
                _maxDate = value;
                UpdateValidator(); // Cập nhật validator mỗi khi giá trị thay đổi
            }
        }

        public DateRule()
        {
            UpdateValidator();
        }

        protected override void UpdateValidator()
        {
            if (DateTime.TryParse(_minDate, out DateTime minDate) && DateTime.TryParse(_maxDate, out DateTime maxDate))
            {
                var builder = new ValidateBuilder();
                builder.AddBaseValidator(new DateRangedValidator(minDate, maxDate, _errorMessage ?? $"Date must be between {minDate.ToShortDateString()} and {maxDate.ToShortDateString()}.", _validMessage ?? "Date is Valid"));
                this._validator = builder.Build();
            }
            else
            {
                throw new FormatException("Invalid date format for MinDate or MaxDate.");
            }
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
