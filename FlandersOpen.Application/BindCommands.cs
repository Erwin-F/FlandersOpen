using FlandersOpen.Application.Competitions;
using FlandersOpen.Application.Pitches;
using FlandersOpen.Application.Referees;
using FlandersOpen.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Application
{
    public static class BindCommands
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddScoped<ICommandBus, CommandBus>();

            services.AddScoped<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();
            services.AddScoped<ICommandHandler<RegisterUserCommand>, RegisterUserCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();

            services.AddScoped<ICommandHandler<DeleteCompetitionCommand>, DeleteCompetitionCommandHandler>();
            services.AddScoped<ICommandHandler<CreateCompetitionCommand>, CreateCompetitionCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateCompetitionCommand>, UpdateCompetitionCommandHandler>();

            services.AddScoped<ICommandHandler<AddPitchCommand>, AddPitchCommandHandler>();
            services.AddScoped<ICommandHandler<AddTimeslotsToPitchCommand>, AddTimeslotsToPitchCommandHandler>();
            services.AddScoped<ICommandHandler<RemovePitchCommand>, RemovePitchCommandHandler>();
            services.AddScoped<ICommandHandler<UpdatePitchCommand>, UpdatePitchCommandHandler>();

            services.AddScoped<ICommandHandler<AddRefereeCommand>, AddRefereeCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveRefereeCommand>, RemoveRefereeCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRefereeCommand>, UpdateRefereeCommandHandler>();
        }
    }
}
