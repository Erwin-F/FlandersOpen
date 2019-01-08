using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Infrastructure;
using FlandersOpen.Read.Dtos;
using FlandersOpen.Read.Users;

namespace FlandersOpen.Read.Competitions
{
    public class GetAllCompetitions : IQuery<IEnumerable<CompetitionDto>>
    {
    }

    internal sealed class GetAllUsersHandler : IQueryHandler<GetAllCompetitions, IEnumerable<CompetitionDto>>
    {
        private readonly ConnectionStrings _connectionstrings;

        public GetAllUsersHandler(ConnectionStrings connectionstrings)
        {
            _connectionstrings = connectionstrings;
        }

        public IEnumerable<CompetitionDto> Handle(GetAllCompetitions query)
        {
            const string sql = @"SELECT Id, Name, ShortName, Color FROM fo.Cometitions";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var competitions = connection.Query<CompetitionDto>(sql);

                return competitions;
            }
        }
    }
}