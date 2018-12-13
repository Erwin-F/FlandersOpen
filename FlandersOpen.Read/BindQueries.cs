using System.Collections.Generic;
using FlandersOpen.Read.Dtos;
using FlandersOpen.Read.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Read
{
    public static class BindQueries
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddSingleton<QueryService>();

            services.AddTransient<IQueryHandler<GetUserById, UserDto>, GetUserByIdHandler>();
            services.AddTransient<IQueryHandler<GetAuthenticatedUser, AuthenticatedUserDto>, GetAuthenticatedUserHandler>();
            services.AddTransient<IQueryHandler<GetAllUsers, IEnumerable<UserDto>>, GetAllUsersHandler>();
        }
    }
}
