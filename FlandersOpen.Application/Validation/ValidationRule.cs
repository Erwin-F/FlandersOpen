using System;
using System.Linq.Expressions;

namespace FlandersOpen.Application.Validation
{
    public class ValidationRule : IValidationRule
    {
        public string PropertyName { get; }
        public string Message { get; protected internal set; }        
        public bool IsValid { get; protected internal set; }
        internal string Value { get; }

        private ValidationRule(Expression<Func<string>> toValidate)
        {
            var expressionBody = (MemberExpression)toValidate.Body;
            
            Value = (string)toValidate.Compile().DynamicInvoke();
            PropertyName = expressionBody.Member.Name;
            IsValid = true;
        }

        public static ValidationRule For(Expression<Func<string>> toValidate)
        {
            return new ValidationRule(toValidate);
        }
    }
}