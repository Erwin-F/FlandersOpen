using FlandersOpen.Domain.Entities;

namespace FlandersOpen.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
        bool UsernameAlreadyExists(string username);
    }
}
