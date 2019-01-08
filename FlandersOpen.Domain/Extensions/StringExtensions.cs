using System.Globalization;

namespace FlandersOpen.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsHexadecimal(this string value)
        {
            return int.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        public static bool InColorRange(this string value)
        {
            return value.Length == 6 && value.IsHexadecimal();
        }
    }
}