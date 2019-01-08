using FlandersOpen.Infrastructure;
using FlandersOpen.Persistence;

namespace FlandersOpen.Application.Users
{
    public sealed class DeleteUserCommand : BaseCommand
    {
        public int Id { get; set; }
    }

    internal sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result Handle(DeleteUserCommand command)
        {
            var user = _context.Users.Find(command.Id);
            if (user == null) return Result.Fail($"No user found for Id {command.Id}");
            
            _context.Users.Remove(user);

            return Result.Ok();
        }
    }
}