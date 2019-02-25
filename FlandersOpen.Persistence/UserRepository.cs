using System.Linq;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Domain.Entities;

namespace FlandersOpen.Persistence
{
    public sealed class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User GetByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public bool UsernameAlreadyExists(string username)
        {
            return _context.Users.Any(u => u.HasSameUsername(username));
        }
    }
}
