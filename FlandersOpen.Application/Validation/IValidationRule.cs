namespace FlandersOpen.Application.Validation
{
    public interface IValidationRule
    {
        string PropertyName { get; }
        string Message { get; }
        
        bool IsValid { get; }
    }
}