//using ValidationFramework.Base;
//using ValidationFramework.Common;

//namespace ValidationFramework.Implement.CoreValidator
//{
//    public class ConfirmPasswordValidator : BaseValidator
//    {
//        private readonly string _password;

//        public ConfirmPasswordValidator(string password)
//        {
//            _password = password;
//        }

//        public override ValidateRecord Validate(object? content)
//        {
//            if (content == null || content.ToString() != _password)
//            {
//                return new ValidateRecord
//                {
//                    IsValid = false,
//                    Message = "Confirm password must match the password."
//                };
//            }

//            return new ValidateRecord
//            {
//                IsValid = true
//            };
//        }
//    }
//}
