using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFramework.Implement.CoreValidator.Date
{
    class PastDateValidator : BaseValidator
    {
        public PastDateValidator(string errorMessage = "Date must be in the past", string validMessage = "Date is in the past")
        {
            _errorMessage = errorMessage;
            _validMessage = validMessage;
        }

        protected override bool IsValid(object obj)
        {
            if (obj is string input && DateTime.TryParse(input, out DateTime date))
            {
                return date < DateTime.Now;
            }
            return false; // Không hợp lệ nếu không phải chuỗi ngày
        }
    }
}
