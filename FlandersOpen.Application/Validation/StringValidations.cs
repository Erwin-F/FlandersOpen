using FlandersOpen.Domain.Extensions;

namespace FlandersOpen.Application.Validation
{
    public static class StringValidations
    {
        public static ValidationRule NotEmpty(this ValidationRule<string> rule, string message = null)
        {
            rule.Message = message ?? ValidationMessages.IsRequired;            
            rule.IsValid = !string.IsNullOrWhiteSpace(rule.Value);

            return rule;
        }

        public static ValidationRule<string> MaxLength(this ValidationRule<string> rule, int maximum, string message = null)
        {
            rule.Message = message ?? string.Format(ValidationMessages.MaxLength, maximum);
            rule.IsValid = string.IsNullOrWhiteSpace(rule.Value) || rule.Value.Length > maximum;
                
            return rule;
        }  
        
        public static ValidationRule<string> IsColorString(this ValidationRule<string> rule, string message = null)
        {
            rule.Message = message ?? ValidationMessages.IsColorString;
            rule.IsValid = rule.Value.InColorRange();

            return rule;
        }
        
        public static ValidationRule<string> SamePasswordValue(this ValidationRule<string> rule, string toCompare, string message = null)
        {
            rule.Message = message ?? ValidationMessages.SamePasswordValue;
            rule.IsValid = rule.Value.Equals(toCompare);

            return rule;
        }        
    }
}