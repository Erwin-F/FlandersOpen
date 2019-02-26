using System;
using FlandersOpen.Application.Core;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Application.Referees
{
    class UpdateRefereeCommand : BaseCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public UpdateRefereeCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => Name).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => ShortName).NotEmpty().MaxLength(5));
        }
    }

    internal sealed class UpdateRefereeCommandHandler : ICommandHandler<UpdateRefereeCommand>
    {
        private readonly IRefereeRepository _repository;

        public UpdateRefereeCommandHandler(IRefereeRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(UpdateRefereeCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");

            var referee = _repository.GetById(command.Id);
            if (referee == null) return Result.Fail($"No referee found for number {command.Id}");

            if (_repository.AlreadyExists(command.Name))
            {
                return Result.Fail($"Pitch number {command.Name} already exists");
            }

            referee.Update(command.Name, new ShortName(command.ShortName));

            return Result.Ok(referee.Id);
        }
    }
}
