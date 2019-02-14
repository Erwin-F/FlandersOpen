using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using FlandersOpen.Infrastructure;
using FlandersOpen.Read.Dtos;

namespace FlandersOpen.Read.Competitions
{
    public class GetCompetitionById : IQuery<CompetitionDto>
    {
        public int Id { get; set; }
    }

    internal sealed class GetCompetitionByIdHandler : IQueryHandler<GetCompetitionById, CompetitionDto>
    {
        private readonly ConnectionStrings _connectionstrings;

        public GetCompetitionByIdHandler(ConnectionStrings connectionstrings)
        {
            _connectionstrings = connectionstrings;
        }

        public CompetitionDto Handle(GetCompetitionById query)
        {
            const string sql = @"SELECT Id, Name, ShortName, Color FROM fo.Competitions WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var competition = connection.QueryFirstOrDefault<CompetitionDto>(sql, new { query.Id });

                return competition;
            }
        }
    }
}
