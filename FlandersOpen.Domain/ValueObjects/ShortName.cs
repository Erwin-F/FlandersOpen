using System;
using System.Collections.Generic;
using FlandersOpen.Domain.SeedWork;

namespace FlandersOpen.Domain.ValueObjects
{
    public sealed class ShortName : ValueObject
    {
        public string Value { get; }

        public ShortName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 5)
                throw new ArgumentException("Cannot be empty or longer than 5 characters", nameof(value));

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
