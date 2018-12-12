using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Read.Dtos;

namespace FlandersOpen.Read.Users
{
    public sealed class GetUserById : IQuery<UserDto>
    {
        public int Id { get; set; }
    }

    internal sealed class GetUserByIdHandler : IQueryHandler<GetUserById, UserDto>
    {
        private readonly string _connection;

        public GetUserByIdHandler()
        {
            //TODO Insert Connection String
            _connection = "";
        }

        public UserDto Handle(GetUserById query)
        {
            const string sql = @"SELECT Id, Username, Firstname, Lastname FROM Users WHERE Id = @Id";

            using (var connection = new SqlConnection(_connection))
            {
                var user = connection.QueryFirstOrDefault<UserDto>(sql, new { query.Id });

                return user;
            }
        }
    }
}
