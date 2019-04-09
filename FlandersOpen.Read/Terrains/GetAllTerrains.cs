using Dapper;
using FlandersOpen.Application.Core;
using FlandersOpen.Read.Dtos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FlandersOpen.Read.Terrains
{
    public sealed class GetAllTerrains : IQuery<IEnumerable<TerrainDto>>
    {
    }

    internal sealed class GetAllTerrainsHandler : IQueryHandler<GetAllTerrains, IEnumerable<TerrainDto>>
    {
        private readonly ConnectionStrings _connectionstrings;

        public GetAllTerrainsHandler(ConnectionStrings connectionstrings)
        {
            _connectionstrings = connectionstrings;
        }

        public IEnumerable<TerrainDto> Handle(GetAllTerrains query)
        {
            const string sql = @"SELECT t.Id, t.Name, t.CompetitionId, c.Name as CompetitionName, c.Color FROM fo.Teams t INNER JOIN fo.Competitions c ON t.CompetitionId = c.Id";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var terrains = connection.Query<TerrainDto>(sql);

                return terrains;
            }

        }
    }
}