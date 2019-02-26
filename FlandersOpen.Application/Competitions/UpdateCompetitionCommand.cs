using System;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.ValueObjects;
using FlandersOpen.Application.Core;

namespace FlandersOpen.Application.Competitions
{
    public sealed class UpdateCompetitionCommand  : BaseCommand
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Color { get; set; }

        public UpdateCompetitionCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => Name).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => ShortName).NotEmpty().MaxLength(5));
            ValidationRules.Add(ValidationRule.For(() => Color).NotEmpty());      
            ValidationRules.Add(ValidationRule.For(() => Color).IsColorString());
        }
    }

    internal sealed class UpdateCompetitionCommandHandler : ICommandHandler<UpdateCompetitionCommand>
    {
        private readonly ICompetitionRepository _repository;

        public UpdateCompetitionCommandHandler(ICompetitionRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(UpdateCompetitionCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");
            
            var competition =  _repository.GetById(command.Id);
            if (competition == null) return Result.Fail($"No competition found for Id {command.Id}");

            if (_repository.AlreadyExists(command.Name))
            {
                return Result.Fail($"Competition {command.Name} is already taken");
            }            

            competition.Update(command.Name, new ShortName(command.ShortName), new ColorString(command.Color));
            
            _repository.Update(competition);            

            return Result.Ok(competition.Id);
        }
    }
}