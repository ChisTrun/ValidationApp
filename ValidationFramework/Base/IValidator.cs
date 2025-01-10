using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFramework.Common;

namespace ValidationFramework.Base
{
    public interface IValidator
    {
        List<ValidateRecord> Validate(object obj);

        void SetNextValidator(IValidator nextValidator);
    }
}
