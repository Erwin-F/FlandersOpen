using System.Linq;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Core;
using System;

namespace FlandersOpen.Application.Pitches
{
    public sealed class RemovePitchCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }

    internal sealed class RemovePitchCommandHandler : ICommandHandler<RemovePitchCommand>
    {
        private readonly IPitchRepository _repository;

        public RemovePitchCommandHandler(IPitchRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(RemovePitchCommand command)
        {
            var pitch = _repository.GetById(command.Id);
            if (pitch == null) return Result.Fail($"No pitch found for Id {command.Id}");

            _repository.Delete(pitch);

            return Result.Ok();
        }
    }
}
