using System;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;

namespace FlandersOpen.Application.Users
{
    public sealed class RegisterUserCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly ApplicationDbContext _context;

        public RegisterUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result Handle(RegisterUserCommand command)
        {
            if (_context.Users.UsernameAlreadyExists(command.Username))
            {
                return Result.Fail($"Username {command.Username} is already taken");
            }
            
            var user = User.Register(command.Username, command.FirstName, command.LastName, command.Password);
            _context.Users.Add(user);
            _context.SaveChanges();

            return Result.Ok<Guid>(user.Id);
        }
    }
}