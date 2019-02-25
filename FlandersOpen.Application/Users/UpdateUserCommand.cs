using System;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Application.Validation;
using FlandersOpen.Infrastructure;

namespace FlandersOpen.Application.Users
{
    public sealed class UpdateUserCommand : BaseCommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VerifiedPassword { get; set; }

        public UpdateUserCommand()
        {
            ValidationRules.Add(ValidationRule.For(() => FirstName).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => LastName).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => Username).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => Password).NotEmpty());
            ValidationRules.Add(ValidationRule.For(() => VerifiedPassword).NotEmpty().SamePasswordValue(Password));            
        }
    }

    internal sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(UpdateUserCommand command)
        {
            if (!command.IsValid()) return Result.Fail("Invalid command");
            
            var user = _repository.GetById(command.Id);

            if (user == null) return Result.Fail($"No user found for Id {command.Id}");

            if (user.HasDifferentUsername(command.Username) && _repository.UsernameAlreadyExists(command.Username))
            {
                return Result.Fail($"Username {command.Username} is already taken");
            }

            user.Update(command.Username, command.FirstName, command.LastName, command.Password);

            _repository.Update(user);

            return Result.Ok();
        }
    }
}