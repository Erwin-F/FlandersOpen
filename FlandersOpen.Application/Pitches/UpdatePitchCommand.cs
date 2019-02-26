using System;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Validation;
using FlandersOpen.Application.Core;

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
        private readonly IPitchRepository _repository;

        public UpdatePitchCommandHandler(IPitchRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(UpdatePitchCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");
           
            var pitch = _repository.GetById(command.Id);
            if (pitch == null) return Result.Fail($"No pitch found for number {command.Number}");

            if (pitch.Number != command.Number && _repository.NumberAlreadyExists(command.Number))
            {
                return Result.Fail($"Pitch number {command.Number} already exists");
            }

            pitch.Update(command.Name, pitch.Number, pitch.OrderNumber);

            return Result.Ok(pitch.Id);
        }
    }
}
