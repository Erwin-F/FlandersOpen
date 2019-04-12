using System;

namespace FlandersOpen.Domain.Exceptions
{
    public class GameslotsAlreadyFullException : Exception
    {
        public GameslotsAlreadyFullException(string message) : base(message)
        {

        }
    }
}
