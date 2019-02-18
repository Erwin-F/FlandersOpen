using System;
using FlandersOpen.Application.Validation;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;

namespace FlandersOpen.Application.Pitches
{
    public sealed class UpdatePitchCommand : BaseCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int OrderNumber { get; set; }

        public UpdatePitchCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => Name).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => Number).GreaterThan(0));
        }
    }

    internal sealed class UpdatePitchCommandHandler : ICommandHandler<UpdatePitchCommand>
    {
        private readonly ApplicationDbContext _context;

        public UpdatePitchCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result Handle(UpdatePitchCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");

            var pitch = _context.Pitches.Find(command.Id);
            if (pitch == null) return Result.Fail($"No pitch found for number {command.Number}");

            if (pitch.Number != command.Number && _context.Pitches.PitchNumberAlreadyExists(command.Number))
            {
                return Result.Fail($"Pitch number {command.Number} already exists");
            }

            pitch.Update(command.Name, pitch.Number, pitch.OrderNumber);
            _context.SaveChanges();

            return Result.Ok(pitch.Id);
        }
    }
}
