using System.Collections.Generic;
using FlandersOpen.Read.Dtos;
using FlandersOpen.Read.Teams;
using FlandersOpen.Read.Users;
using FlandersOpen.Read.Competitions;
using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Read
{
    public static class BindQueries
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddTransient<IQueryService, QueryService>();

            services.AddTransient<IQueryHandler<GetUserById, UserDto>, GetUserByIdHandler>();
            services.AddTransient<IQueryHandler<GetAllUsers, IEnumerable<UserDto>>, GetAllUsersHandler>();
            services.AddTransient<IQueryHandler<GetAllTeams, IEnumerable<TeamDto>>, GetAllTeamsHandler>();
            services.AddTransient<IQueryHandler<GetAllCompetitions, IEnumerable<CompetitionDto>>, GetAllCompetitionsHandler>();
            services.AddTransient<IQueryHandler<GetCompetitionById, CompetitionDto>, GetCompetitionByIdHandler>();
        }
    }
}
