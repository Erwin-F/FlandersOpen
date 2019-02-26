using System.Linq;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Domain.Entities;

namespace FlandersOpen.Persistence
{
    public class RefereeRepository : EfRepository<Referee>, IRefereeRepository
    {
        public RefereeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool AlreadyExists(string name)
        {
            return _context.Referees.Any(c => c.Name == name);
        }
    }
}
