using System;

namespace FlandersOpen.Domain.Exceptions
{
    public class GameslotWithSameTeamException : Exception
    {
        public GameslotWithSameTeamException(string message) : base(message)
        {

        }
    }
}
