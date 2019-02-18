using System;
using FlandersOpen.Application.Validation;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;

namespace FlandersOpen.Application.Users
{
    public sealed class RegisterUserCommand : BaseCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VerifiedPassword { get; set; }

        public RegisterUserCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => FirstName).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => LastName).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => Username).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => Password).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => VerifiedPassword).NotEmpty().SamePasswordValue(Password));
        }
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
            if (!command.IsValid()) return Result.Fail("Invalid command"); 
            if (_context.Users.UsernameAlreadyExists(command.Username))
            {
                return Result.Fail($"Username {command.Username} is already taken");
            }
            
            var user = User.Register(command.Username, command.FirstName, command.LastName, command.Password);
            _context.Users.Add(user);
            _context.SaveChanges();

            return Result.Ok(user.Id);
        }
    }
}