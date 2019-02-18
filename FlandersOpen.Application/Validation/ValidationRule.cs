using System;
using System.Linq.Expressions;

namespace FlandersOpen.Application.Validation
{
    public static class ValidationRule
    {
        public static ValidationRule<T> For<T>(Expression<Func<T>> toValidate)
        {
            var expressionBody = (MemberExpression)toValidate.Body;
            var value = (T)toValidate.Compile().DynamicInvoke();
            var propertyName = expressionBody.Member.Name;

            return new ValidationRule<T>(value, propertyName);
        }
    }

    public class ValidationRule<T> : IValidationRule
    {
        public T Value { get; }
        public string PropertyName { get; }

        public string Message { get; protected internal set; }

        public bool IsValid { get; protected internal set; }

        internal ValidationRule(T value,string propertyName)
        {
            Value = value;
            PropertyName = propertyName;
            IsValid = true;
        }        
    }    
}