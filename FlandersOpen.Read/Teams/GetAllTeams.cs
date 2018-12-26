using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Infrastructure;
using FlandersOpen.Read.Dtos;

namespace FlandersOpen.Read.Teams
{
    public sealed class GetAllTeams : IQuery<IEnumerable<TeamDto>>
    {
    }

    internal sealed class GetAllTeamsHandler : IQueryHandler<GetAllTeams, IEnumerable<TeamDto>>
    {
        private readonly ConnectionStrings _connectionstrings;

        public GetAllTeamsHandler(ConnectionStrings connectionstrings)
        {
            _connectionstrings = connectionstrings;
        }

        public IEnumerable<TeamDto> Handle(GetAllTeams query)
        {
            const string sql = @"SELECT Id, Username, Firstname, Lastname FROM Users";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var teams = connection.Query<TeamDto>(sql);

                return teams;
            }

        }
    }
}
