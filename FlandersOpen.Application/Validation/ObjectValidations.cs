namespace FlandersOpen.Application.Validation
{
    public static class ObjectValidations
    {
        public static ValidationRule<object> SameValue(this ValidationRule<object> rule, object toCompare, string message = null)
        {
            rule.Message = message ?? ValidationMessages.SameValue;
            rule.IsValid = rule.Value.Equals(toCompare);

            return rule;
        }
    }
}