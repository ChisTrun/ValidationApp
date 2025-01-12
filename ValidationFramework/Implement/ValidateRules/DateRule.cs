using System;
using System.Collections.Generic;
using ValidationFramework.Base;
using ValidationFramework.Common;
using ValidationFramework.Implement.CoreValidator;

namespace ValidationFramework.Implement.ValidateRules
{
    public class DateRule : BaseValidateRule
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }

        public DateRule(DateTime minDate, DateTime maxDate)
        {
            MinDate = minDate;
            MaxDate = maxDate;
        }

        public override List<ValidateRecord> Validate(object obj)
        {
            if (obj is DateTime)
            {
                var builder = new ValidateBuilder();
                builder.AddDateRangedValidator(new DateRangedValidator(MinDate, MaxDate));
                this._validator = builder.Build();
            }

            return new List<ValidateRecord>
            {
                new ValidateRecord
                {
                    Message = "Invalid date format.",
                    IsValid = false
                }
            };
        }
    }
}
