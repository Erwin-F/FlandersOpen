using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;
using System;

namespace FlandersOpen.Application.Pitches
{
    public sealed class AddPitchCommand : BaseCommand
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int OrderNumber { get; set; }

        public AddPitchCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => Name).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => Number).GreaterThan(0));
        }
    }

    internal sealed class AddPitchCommandHandler : ICommandHandler<AddPitchCommand>
    {
        private readonly ApplicationDbContext _context;

        public AddPitchCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result Handle(AddPitchCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");

            if (_context.Pitches.PitchNumberAlreadyExists(command.Number))
            {
                return Result.Fail($"Pitch number {command.Number} already exists");
            }

            var pitch = Pitch.Create(command.Name, command.Number, command.OrderNumber);
            _context.Pitches.Add(pitch);
            _context.SaveChanges();

            return Result.Ok(pitch.Id);
        }
    }
}
