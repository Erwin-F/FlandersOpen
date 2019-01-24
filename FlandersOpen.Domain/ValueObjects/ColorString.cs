using System;
using System.Collections.Generic;
using System.Globalization;
using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.Extensions;

namespace FlandersOpen.Domain.ValueObjects
{
    public sealed class ColorString : ValueObject
    {
        public string Value { get; }

        public ColorString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Cannot be empty", nameof(value));

            if (!value.InColorRange())
                throw new ArgumentException("Needs to be between 000000 and FFFFFF", nameof(value));

            Value = value;
        }

        public ColorString(int red, int green, int blue)
        {
            if (!red.IsInColorRange())
                throw new ArgumentException("Needs to be in range 0 - 255", nameof(red));

            if (!green.IsInColorRange())
                throw new ArgumentException("Needs to be in range 0 - 255", nameof(green));

            if (!blue.IsInColorRange())
                throw new ArgumentException("Needs to be in range 0 - 255", nameof(blue));

            Value = $"{red:X2}{green:X2}{blue:X2}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
