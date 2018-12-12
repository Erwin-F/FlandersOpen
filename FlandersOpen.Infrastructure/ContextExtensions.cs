using System.Linq;
using FlandersOpen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlandersOpen.Infrastructure
{
    public static class ContextExtensions
    {
        public static bool UsernameAlreadyExists(this DbSet<User> users, string username)
        {
            return users.Any(u => u.HasSameUsername(username));
        }
    }
}
