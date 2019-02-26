using FlandersOpen.Application.Core;

namespace FlandersOpen.Application
{
    public interface ICommandBus
    {
        Result Dispatch(ICommand command);
    }
}
