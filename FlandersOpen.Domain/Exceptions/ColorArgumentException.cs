using System;

namespace FlandersOpen.Domain.Exceptions
{
    public class ColorArgumentException : ArgumentException
    {
        public ColorArgumentException(string message, string paramName) : base(message, paramName)
        {

        }
    }
}
