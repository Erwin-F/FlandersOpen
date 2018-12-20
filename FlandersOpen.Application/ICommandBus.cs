using FlandersOpen.Infrastructure;

namespace FlandersOpen.Application
{
    public interface ICommandBus
    {
        Result Dispatch(ICommand command);
    }
}
