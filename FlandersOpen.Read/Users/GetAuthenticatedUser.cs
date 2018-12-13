using System;
using System.Data.SqlClient;
using Dapper;
using FlandersOpen.Infrastructure;
using FlandersOpen.Read.Dtos;
using Microsoft.Extensions.Options;

namespace FlandersOpen.Read.Users
{
    public sealed class GetAuthenticatedUser : IQuery<AuthenticatedUserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    internal sealed class GetAuthenticatedUserHandler : IQueryHandler<GetAuthenticatedUser, AuthenticatedUserDto>
    {
        private readonly ConnectionStrings _connectionstrings;

        public GetAuthenticatedUserHandler(ConnectionStrings connectionstrings)
        {
            _connectionstrings = connectionstrings;
        }

        public AuthenticatedUserDto Handle(GetAuthenticatedUser query)
        {
            const string sql = @"SELECT Id, Username, Firstname, Lastname, PasswordHash, PasswordSalt FROM Users WHERE Username = @Username";

            using (var connection = new SqlConnection(_connectionstrings.Default))
            {
                var user = connection.QueryFirstOrDefault<UserWithPasswordDto>(sql, new { query.Username });

                if (string.IsNullOrWhiteSpace(user?.Username)) return null;
                if (string.IsNullOrWhiteSpace(query.Password)) return null;

                if (!VerifyPasswordHash(query.Password, user.PasswordHash, user.PasswordSalt)) return null;

                return new AuthenticatedUserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname
                };
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}