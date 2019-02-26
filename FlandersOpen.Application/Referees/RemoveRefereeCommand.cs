using System;
using System.Collections.Generic;
using System.Text;
using FlandersOpen.Application.Core;
using FlandersOpen.Application.Repositories;

namespace FlandersOpen.Application.Referees
{
    public sealed class RemoveRefereeCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }

    internal sealed class RemoveRefereeCommandHandler : ICommandHandler<RemoveRefereeCommand>
    {
        private readonly IRefereeRepository _repository;

        public RemoveRefereeCommandHandler(IRefereeRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(RemoveRefereeCommand command)
        {
            var pitch = _repository.GetById(command.Id);
            if (pitch == null) return Result.Fail($"No referee found for Id {command.Id}");

            _repository.Delete(pitch);

            return Result.Ok();
        }
    }
}
