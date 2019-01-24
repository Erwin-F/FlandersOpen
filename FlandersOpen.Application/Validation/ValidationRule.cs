using System;
using System.Linq.Expressions;

namespace FlandersOpen.Application.Validation
{
    public class ValidationRule<T> : IValidationRule
    {
        public string PropertyName { get; }
        public string Message { get; protected internal set; }        
        public bool IsValid { get; protected internal set; }
        internal T Value { get; }

        private ValidationRule(Expression<Func<T>> toValidate)
        {
            var expressionBody = (MemberExpression)toValidate.Body;
            
            Value = (T)toValidate.Compile().DynamicInvoke();
            PropertyName = expressionBody.Member.Name;
            IsValid = true;
        }

        public static ValidationRule<T> For(Expression<Func<T>> toValidate)
        {
            return new ValidationRule<T>(toValidate);
        }
    }
}