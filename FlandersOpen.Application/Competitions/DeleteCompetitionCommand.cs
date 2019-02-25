using System;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Infrastructure;

namespace FlandersOpen.Application.Competitions
{
    public sealed class DeleteCompetitionCommand: BaseCommand
    {
        public Guid Id { get; set; }
    }

    internal sealed class DeleteCompetitionCommandHandler : ICommandHandler<DeleteCompetitionCommand>
    {
        private readonly ICompetitionRepository _repository;

        public DeleteCompetitionCommandHandler(ICompetitionRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteCompetitionCommand command)
        {
            var competition = _repository.GetById(command.Id);
            if (competition == null) return Result.Fail($"No competition found for Id {command.Id}");
            
            _repository.Delete(competition);

            return Result.Ok();
        }
    }    
}