namespace FlandersOpen.Application.Validation
{
    public static class IntegerValidations
    {
        public static ValidationRule<int> GreaterThan(this ValidationRule<int> rule, int number, string message = null)
        {
            rule.Message = message ?? string.Format(ValidationMessages.GreaterThan, number);
            rule.IsValid = rule.Value > number;

            return rule;
        }
    }
}
