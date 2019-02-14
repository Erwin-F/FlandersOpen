using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;

namespace FlandersOpen.Application.Competitions
{
    public sealed class DeleteCompetitionCommand: BaseCommand
    {
        public int Id { get; set; }
    }

    internal sealed class DeleteCompetitionCommandHandler : ICommandHandler<DeleteCompetitionCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteCompetitionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result Handle(DeleteCompetitionCommand command)
        {
            var competition = _context.Competitions.Find(command.Id);
            if (competition == null) return Result.Fail($"No competition found for Id {command.Id}");
            
            _context.Competitions.Remove(competition);

            return Result.Ok();
        }
    }    
}