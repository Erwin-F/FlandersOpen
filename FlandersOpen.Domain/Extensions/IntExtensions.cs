namespace FlandersOpen.Domain.Extensions
{
    public static class IntExtensions
    {
        public static bool IsInColorRange(this int value)
        {
            return value >= 0 && value <= 255;
        }

        public static bool IsInHourRange(this int value)
        {
            return value >= 0 && value <= 24;
        }

        public static bool IsInMinuteRange(this int value)
        {
            return value >= 0 && value <= 60;
        }
    }
}