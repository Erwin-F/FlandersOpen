using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Application.Core;
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
            const string sql = @"SELECT t.Id, t.Name, t.CompetitionId, c.Name as CompetitionName, c.Color FROM fo.Teams t INNER JOIN fo.Competitions c ON t.CompetitionId = c.Id";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var teams = connection.Query<TeamDto>(sql);

                return teams;
            }

        }
    }
}
