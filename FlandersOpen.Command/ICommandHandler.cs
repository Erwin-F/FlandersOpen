using FlandersOpen.Infrastructure;

namespace FlandersOpen.Command
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
