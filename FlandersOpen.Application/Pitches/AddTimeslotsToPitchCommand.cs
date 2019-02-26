using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.ValueObjects;
using FlandersOpen.Application.Core;
using System;

namespace FlandersOpen.Application.Pitches
{
    public sealed class AddTimeslotsToPitchCommand : BaseCommand
    {
        public Guid Id { get; set; }
        public int EventDurationInMinutes { get; set; }
        public Time StartTime { get; set; }
        public Time EndTime { get; set; }

        public AddTimeslotsToPitchCommand()
        {            
            ValidationRules.Add(ValidationRule.For(() => EventDurationInMinutes).GreaterThan(0));
        }
    }

    internal sealed class AddTimeslotsToPitchCommandHandler : ICommandHandler<AddTimeslotsToPitchCommand>
    {
        private readonly IPitchRepository _repository;

        public AddTimeslotsToPitchCommandHandler(IPitchRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddTimeslotsToPitchCommand command)
        {
            var pitch = _repository.GetById(command.Id);
            if (pitch == null) return Result.Fail($"No pitch found for id {command.Id}");

            pitch.AddContinuousTimeslots(command.StartTime, command.EndTime, command.EventDurationInMinutes);
            _repository.Update(pitch);
            
            return Result.Ok();
        }
    }
}
