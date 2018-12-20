using FlandersOpen.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Application
{
    public static class BindServices
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
