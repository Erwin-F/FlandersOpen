using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Infrastructure;
using FlandersOpen.Read.Dtos;
using Microsoft.Extensions.Options;

namespace FlandersOpen.Read.Users
{
    public sealed class GetAllUsers : IQuery<IEnumerable<UserDto>>
    {
    }

    internal sealed class GetAllUsersHandler : IQueryHandler<GetAllUsers, IEnumerable<UserDto>>
    {
        private readonly ConnectionStrings _connectionstrings;

        public GetAllUsersHandler(ConnectionStrings connectionstrings)
        {
            _connectionstrings = connectionstrings;
        }

        public IEnumerable<UserDto> Handle(GetAllUsers query)
        {
            const string sql = @"SELECT Id, Username, Firstname, Lastname FROM Users";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var users = connection.Query<UserDto>(sql);

                return users;
            }
        }
    }
}
