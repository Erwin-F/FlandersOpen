using FlandersOpen.Application.Core;

namespace FlandersOpen.Application
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
