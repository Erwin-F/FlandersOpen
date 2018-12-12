using FlandersOpen.Command.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Command
{
    public static class BindCommands
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddSingleton<CommandBus>();

            services.AddTransient<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();            
        }
    }
}
