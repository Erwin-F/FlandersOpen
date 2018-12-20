using System;

namespace FlandersOpen.Read.Dtos
{
    public sealed class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
