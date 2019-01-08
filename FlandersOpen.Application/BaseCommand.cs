using System;
using System.Collections.Generic;
using FlandersOpen.Application.Validation;

namespace FlandersOpen.Application
{
    public abstract class BaseCommand : ICommand
    {
        public Dictionary<string, IList<string>> ValidationMessages { get; }
        
        public List<IValidationRule> ValidationRules { get; }

        private bool? _isValid;

        protected BaseCommand()
        {
            ValidationMessages = new Dictionary<string, IList<string>>();
            ValidationRules = new List<IValidationRule>();            
        }

        public bool IsValid()
        {
            if (_isValid != null) return _isValid.Value;
            
            foreach (var rule in ValidationRules)
            {
                if (rule.IsValid) continue;
                
                if (ValidationMessages.ContainsKey(rule.PropertyName))
                {
                    ValidationMessages[rule.PropertyName].Add(rule.Message);
                }
                else
                {
                    ValidationMessages.Add(rule.PropertyName, new List<string>{ rule.Message });                        
                }
            }

            _isValid = ValidationMessages.Count == 0;
            return _isValid.Value;
        }    
    }    
}