using System;

namespace FlandersOpen.Application.Services
{
    public sealed class AuthenticatedUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Token { get; set; }
    }
}
