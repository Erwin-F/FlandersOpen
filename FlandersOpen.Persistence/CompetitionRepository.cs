using FlandersOpen.Domain.Entities;
using FlandersOpen.Application.Repositories;
using System.Linq;

namespace FlandersOpen.Persistence
{
    public sealed class CompetitionRepository : EfRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool AlreadyExists(string name)
        {
            return _context.Competitions.Any(c => c.Name == name);
        }

    }
}
