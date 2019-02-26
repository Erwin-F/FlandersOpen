using System;
using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Application.Core;
using FlandersOpen.Read.Dtos;

namespace FlandersOpen.Read.Users
{
    public sealed class GetUserById : IQuery<UserDto>
    {
        public Guid Id { get; set; }
    }

    internal sealed class GetUserByIdHandler : IQueryHandler<GetUserById, UserDto>
    {
        private readonly ConnectionStrings _connectionstrings;

        public GetUserByIdHandler(ConnectionStrings connectionstrings)
        {
            _connectionstrings = connectionstrings;
        }

        public UserDto Handle(GetUserById query)
        {
            const string sql = @"SELECT Id, Username, Firstname, Lastname, Enabled FROM fo.Users WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var user = connection.QueryFirstOrDefault<UserDto>(sql, new { query.Id });

                return user;
            }
        }
    }
}
