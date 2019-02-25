using System;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Infrastructure;
using FlandersOpen.Domain.ValueObjects;
using FlandersOpen.Application.Repositories;
using System.Threading.Tasks;

namespace FlandersOpen.Application.Competitions
{
    public sealed class CreateCompetitionCommand : BaseCommand
    {        
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Color { get; set; }

        public CreateCompetitionCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => Name).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => ShortName).NotEmpty().MaxLength(5));
            ValidationRules.Add(ValidationRule.For(() => Color).NotEmpty());      
            ValidationRules.Add(ValidationRule.For(() => Color).IsColorString());
        }
    }

    internal sealed class CreateCompetitionCommandHandler : ICommandHandler<CreateCompetitionCommand>
    {
        private readonly ICompetitionRepository _repository;

        public CreateCompetitionCommandHandler(ICompetitionRepository repository)
        {
            _repository = repository;
        }
        
        public Result Handle(CreateCompetitionCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command"); 
            
            if (_repository.AlreadyExists(command.Name))
            {
                return Result.Fail($"Competition {command.Name} is already taken");
            }            

            var competition = Competition.Build(command.Name, new ShortName(command.ShortName), new ColorString(command.Color));
            _repository.Add(competition);
            
            return Result.Ok(competition.Id);
        }
    }
}
