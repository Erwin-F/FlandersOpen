using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Read.Dtos;

namespace FlandersOpen.Read.Users
{
    public sealed class GetAllUsers : IQuery<IEnumerable<UserDto>>
    {
    }

    internal sealed class GetAllUsersHandler : IQueryHandler<GetAllUsers, IEnumerable<UserDto>>
    {
        private readonly string _connection;

        public GetAllUsersHandler()
        {
            //TODO Insert Connection String
            _connection = "";
        }

        public IEnumerable<UserDto> Handle(GetAllUsers query)
        {
            const string sql = @"SELECT Id, Username, Firstname, Lastname FROM Users";

            using (var connection = new SqlConnection(_connection))
            {
                var users = connection.Query<UserDto>(sql);

                return users;
            }
        }
    }
}
