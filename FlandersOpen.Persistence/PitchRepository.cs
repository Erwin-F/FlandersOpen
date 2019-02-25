using System.Linq;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlandersOpen.Persistence
{
    public sealed class PitchRepository : EfRepository<Pitch>, IPitchRepository
    {
        public PitchRepository(ApplicationDbContext context) :base(context)
        {
        }

        public bool NumberAlreadyExists(int nr)
        {
            return _context.Pitches.Any(p => p.Number == nr);
        }

        public Pitch GetByNumberWithItems(int nr)
        {
            return _context.Pitches
                .Include(p => p.Timeslots)
                .FirstOrDefault(p => p.Number == nr);
        }
    }
}
