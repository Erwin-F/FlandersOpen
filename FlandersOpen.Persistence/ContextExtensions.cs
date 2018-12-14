using System.Linq;
using FlandersOpen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlandersOpen.Persistence
{
    public static class ContextExtensions
    {
        public static bool UsernameAlreadyExists(this DbSet<User> users, string username)
        {
            return users.Any(u => u.HasSameUsername(username));
        }
    }
}
