using System;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;
using FlandersOpen.Domain.ValueObjects;

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
        private readonly ApplicationDbContext _context;

        public CreateCompetitionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public Result Handle(CreateCompetitionCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command"); 
            
            if (_context.Competitions.CompetitionAlreadyExists(command.Name))
            {
                return Result.Fail($"Competition {command.Name} is already taken");
            }            

            var competition = Competition.Create(command.Name, new ShortName(command.ShortName), new ColorString(command.Color));
            _context.Competitions.Add(competition);
            _context.SaveChanges();
            
            return Result.Ok(competition.Id);
        }
    }
}
