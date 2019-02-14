using System.Linq;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;

namespace FlandersOpen.Application.Pitches
{
    public sealed class RemovePitchCommand : BaseCommand
    {
        public int Number { get; set; }
    }

    internal sealed class RemovePitchCommandHandler : ICommandHandler<RemovePitchCommand>
    {
        private readonly ApplicationDbContext _context;

        public RemovePitchCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result Handle(RemovePitchCommand command)
        {
            var pitch = _context.Pitches.FirstOrDefault(p => p.Number == command.Number);
            if (pitch == null) return Result.Fail($"No pitch found for number {command.Number}");

            _context.Pitches.Remove(pitch);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
