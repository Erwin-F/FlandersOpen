using System;
using FlandersOpen.Application.Repositories;
using FlandersOpen.Infrastructure;

namespace FlandersOpen.Application.Users
{
    public sealed class DeleteUserCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }

    internal sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteUserCommand command)
        {
            var user = _repository.GetById(command.Id);
            if (user == null) return Result.Fail($"No user found for Id {command.Id}");

            _repository.Delete(user);

            return Result.Ok();
        }
    }
}