using System.Linq;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Infrastructure;

namespace FlandersOpen.Application.Pitches
{
    public sealed class RemovePitchCommand : BaseCommand
    {
        public int Number { get; set; }
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
            var pitch = _repository.GetByNumberWithItems(command.Number);
            if (pitch == null) return Result.Fail($"No pitch found for number {command.Number}");

            _repository.Delete(pitch);

            return Result.Ok();
        }
    }
}
