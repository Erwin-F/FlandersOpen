using System;
using System.Collections.Generic;
using System.Globalization;
using FlandersOpen.Domain.SeedWork;

namespace FlandersOpen.Domain.ValueObjects
{
    public class ColorString : ValueObject
    {
        public string Value { get; }

        public ColorString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Cannot be empty", nameof(value));

            if (value.Length < 6 || value.Length > 6 || !IsHexadecimal(value))
                throw new ArgumentException("Needs to be between 000000 and FFFFFF", nameof(value));

            Value = value;
        }

        public ColorString(int red, int green, int blue)
        {
            if (!IsInColorRange(red))
                throw new ArgumentException("Needs to be in range 0 - 255", nameof(red));

            if (!IsInColorRange(green))
                throw new ArgumentException("Needs to be in range 0 - 255", nameof(green));

            if (!IsInColorRange(blue))
                throw new ArgumentException("Needs to be in range 0 - 255", nameof(blue));

            Value = $"{red:X2}{green:X2}{blue:X2}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private bool IsHexadecimal(string value)
        {
            return int.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        private bool IsInColorRange(int value)
        {
            return value >= 0 && value <= 255;
        }
    }
}
