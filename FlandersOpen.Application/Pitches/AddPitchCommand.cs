using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Application.Core;

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
        private readonly IPitchRepository _repository;

        public AddPitchCommandHandler(IPitchRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddPitchCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");

            if (_repository.NumberAlreadyExists(command.Number))
            {
                return Result.Fail($"Pitch number {command.Number} already exists");
            }

            var pitch = Pitch.Build(command.Name, command.Number, command.OrderNumber);

            _repository.Add(pitch);

            return Result.Ok(pitch.Id);
        }
    }
}
