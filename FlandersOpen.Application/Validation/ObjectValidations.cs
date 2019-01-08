namespace FlandersOpen.Application.Validation
{
    public static class ObjectValidations
    {
        public static ValidationRule SameValue(this ValidationRule rule, object toCompare, string message = null)
        {
            rule.Message = message ?? ValidationMessages.SameValue;
            rule.IsValid = rule.Value.Equals(toCompare);

            return rule;
        }
    }
}