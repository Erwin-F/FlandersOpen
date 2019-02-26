using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.ValueObjects;
using FlandersOpen.Application.Core;

namespace FlandersOpen.Application.Referees
{
    public sealed class AddRefereeCommand : BaseCommand
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public AddRefereeCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => Name).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => ShortName).NotEmpty().MaxLength(5));
        }
    }

    internal sealed class AddRefereeCommandHandler : ICommandHandler<AddRefereeCommand>
    {
        private readonly IRefereeRepository _repository;

        public AddRefereeCommandHandler(IRefereeRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddRefereeCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");

            if (_repository.AlreadyExists(command.Name))
            {
                return Result.Fail($"Referee {command.Name} already exists");
            }

            var referee = Referee.Build(command.Name, new ShortName(command.ShortName));
            _repository.Add(referee);

            return Result.Ok(referee.Id);
        }
    }
}