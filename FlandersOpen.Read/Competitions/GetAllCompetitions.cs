using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Application.Core;
using FlandersOpen.Read.Dtos;

namespace FlandersOpen.Read.Competitions
{
    public class GetAllCompetitions : IQuery<IEnumerable<CompetitionDto>>
    {
    }

    internal sealed class GetAllCompetitionsHandler : IQueryHandler<GetAllCompetitions, IEnumerable<CompetitionDto>>
    {
        private readonly ConnectionStrings _connectionstrings;

        public GetAllCompetitionsHandler(ConnectionStrings connectionstrings)
        {
            _connectionstrings = connectionstrings;
        }

        public IEnumerable<CompetitionDto> Handle(GetAllCompetitions query)
        {
            const string sql = @"SELECT Id, Name, ShortName, Color FROM fo.Competitions";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var competitions = connection.Query<CompetitionDto>(sql);

                return competitions;
            }
        }
    }
}