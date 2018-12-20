using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FlandersOpen.Application.Services
{
    public sealed class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public AuthenticationService(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public AuthenticatedUserDto GetToken(UserCredentials credentials)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == credentials.Username);

            if (user == null) return null;

            if (user.IsCorrectPassword(credentials.Password))
            {
                return new AuthenticatedUserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Firstname = user.FirstName,
                    Lastname = user.LastName,
                    Token = GetToken(_appSettings.Secret, user.Id)
                };                    
            }

            return null;
        }

        private static string GetToken(string secret, Guid id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())                    
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

    }
}