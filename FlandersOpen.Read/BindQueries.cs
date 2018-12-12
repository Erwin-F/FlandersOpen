using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Read
{
    public static class BindQueries
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddSingleton<QueryService>();

            /*
services.AddTransient<ICommandHandler<DisenrollCommand>, DisenrollCommandHandler>();
services.AddTransient<IQueryHandler<GetListQuery, List<StudentDto>>, GetListQueryHandler>();

 */


        }
    }
}
