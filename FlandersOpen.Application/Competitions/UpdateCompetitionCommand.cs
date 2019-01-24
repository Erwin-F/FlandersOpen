using System;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.ValueObjects;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;

namespace FlandersOpen.Application.Competitions
{
    public class UpdateCompetitionCommand  : BaseCommand
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Color { get; set; }

        public UpdateCompetitionCommand()
        {
            ValidationRules.Add(ValidationRule<string>.For(() => Name).NotEmpty());
            ValidationRules.Add(ValidationRule<string>.For(() => ShortName).NotEmpty().MaxLength(5));
            ValidationRules.Add(ValidationRule<string>.For(() => Color).NotEmpty());      
            ValidationRules.Add(ValidationRule<string>.For(() => Color).IsColorString());
        }
    }

    internal sealed class UpdateCompetitionCommandHandler : ICommandHandler<UpdateCompetitionCommand>
    {
        private readonly ApplicationDbContext _context;

        public UpdateCompetitionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result Handle(UpdateCompetitionCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");
            
            var competition = _context.Competitions.Find(command.Id);
            if (competition == null) return Result.Fail($"No competition found for Id {command.Id}");

            if (_context.Competitions.CompetitionAlreadyExists(command.Name))
            {
                return Result.Fail($"Competition {command.Name} is already taken");
            }            

            competition.Update(command.Name, new ShortName(command.ShortName), new ColorString(command.Color));
            
            _context.Competitions.Update(competition);
            _context.SaveChanges();

            return Result.Ok(competition.Id);
        }
    }
}