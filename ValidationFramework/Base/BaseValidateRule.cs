using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFramework.Common;

namespace ValidationFramework.Base
{
    public  abstract class BaseValidateRule
    {
        protected BaseValidator? _validator;
        public abstract  List<ValidateRecord> Validate(object obj);

        protected abstract void UpdateValidator();

        protected string _errorMessage = null;

        protected string _validMessage = null;

        protected string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                UpdateValidator();
            }
        }

        protected string ValidMessage
        {
            get => _validMessage;
            set
            {
                _validMessage = value;
                UpdateValidator();
            }
        }

    }
}
