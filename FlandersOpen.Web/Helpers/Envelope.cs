using System;
using System.Collections;
using System.Collections.Generic;

namespace FlandersOpen.Web.Helpers
{
    public class Envelope<T>
    {
        public T Result { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }
        
        public IDictionary<string, IList<string>> ValidationMessages { get; }

        protected internal Envelope(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }

        protected internal Envelope(IDictionary<string, IList<string>> validationMessages)
        {
            ValidationMessages = validationMessages;
            TimeGenerated = DateTime.UtcNow;
        }
    }

    public sealed class Envelope : Envelope<string>
    {
        private Envelope(string errorMessage)
            : base(null, errorMessage)
        {
        }

        private Envelope(IDictionary<string, IList<string>> validationMessages) 
            : base(validationMessages)
        {            
        }

        private Envelope() : base(null, null)
        {            
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope();
        }

        public static Envelope Invalid(Dictionary<string, IList<string>> validationMessages)
        {
            return new Envelope(validationMessages);
        }
        
        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }
    }
}