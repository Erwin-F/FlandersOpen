using FlandersOpen.Domain.Entities;

namespace FlandersOpen.Application.Repositories
{
    public interface IRefereeRepository : IRepository<Referee>
    {
        bool AlreadyExists(string name);
    }
}
