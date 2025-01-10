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
        public abstract List<ValidateRecord> Validate(object obj);
    }
}
