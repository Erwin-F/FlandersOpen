using System;
using System.Collections.Generic;
using System.Text;
using FlandersOpen.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Persistence
{
    public static class BindRepositories
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddScoped<IPitchRepository, PitchRepository>();
            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            services.AddScoped<IRefereeRepository, RefereeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
