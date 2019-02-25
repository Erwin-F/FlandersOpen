using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.ValueObjects;
using FlandersOpen.Infrastructure;

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
        private readonly IPitchRepository _repository;

        public AddTimeslotsToPitchCommandHandler(IPitchRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddTimeslotsToPitchCommand command)
        {
            var pitch = _repository.GetByNumberWithItems(command.PitchNumber);
            if (pitch == null) return Result.Fail($"No pitch found for number {command.PitchNumber}");

            pitch.AddContinuousTimeslots(command.StartTime, command.EndTime, command.EventDurationInMinutes);
            _repository.Update(pitch);
            
            return Result.Ok();
        }
    }
}
