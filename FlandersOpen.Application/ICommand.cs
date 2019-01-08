using System.Collections.Generic;
using FlandersOpen.Application.Validation;

namespace FlandersOpen.Application
{
    public interface ICommand
    {
        Dictionary<string, IList<string>> ValidationMessages { get; }
        
        List<IValidationRule> ValidationRules { get; }        
    }
}
