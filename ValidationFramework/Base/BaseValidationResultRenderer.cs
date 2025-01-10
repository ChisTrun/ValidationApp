using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFramework.Common;
using ValidationLib.UIControl;

namespace ValidationFramework.Base
{
    public abstract class BaseValidationResultRenderer
    {
        protected ValidationHelper? _validationHelper;

        public BaseValidationResultRenderer()
        {
        }

       public void AddValidationHelper(ValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;
        }   

        public void RemoveValidationHelper()
        {
            _validationHelper = null;
        }   

        public abstract void RenderResult(   List<ValidateRecord> summary);
    }
}
