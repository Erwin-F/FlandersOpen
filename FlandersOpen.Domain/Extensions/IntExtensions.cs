namespace FlandersOpen.Domain.Extensions
{
    public static class IntExtensions
    {
        public static bool IsInColorRange(this int value)
        {
            return value >= 0 && value <= 255;
        }
    }
}