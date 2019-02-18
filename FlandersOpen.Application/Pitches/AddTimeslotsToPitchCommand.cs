using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.ValueObjects;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;

namespace FlandersOpen.Application.Pitches
{
    public sealed class AddTimeslotsToPitchCommand : BaseCommand
    {
        public int PitchNumber { get; set; }
        public int EventDurationInMinutes { get; set; }
        public Time StartTime { get; set; }
        public Time EndTime { get; set; }

        public AddTimeslotsToPitchCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => PitchNumber).GreaterThan(0));
            ValidationRules.Add(ValidationRule.For(() => EventDurationInMinutes).GreaterThan(0));
        }
    }

    internal sealed class AddTimeslotsToPitchCommandHandler : ICommandHandler<AddTimeslotsToPitchCommand>
    {
        private readonly ApplicationDbContext _context;

        public AddTimeslotsToPitchCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result Handle(AddTimeslotsToPitchCommand command)
        {
            var pitch = _context.Pitches.FirstOrDefault(p => p.Number == command.PitchNumber);
            if (pitch == null) return Result.Fail($"No pitch found for number {command.PitchNumber}");

            pitch.AddContinuousTimeslots(command.StartTime, command.EndTime, command.EventDurationInMinutes);

            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
