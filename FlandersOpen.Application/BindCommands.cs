using FlandersOpen.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Application
{
    public static class BindCommands
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddSingleton<CommandBus>();

            services.AddTransient<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();
            services.AddTransient<ICommandHandler<RegisterUserCommand>, RegisterUserCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
        }
    }
}
