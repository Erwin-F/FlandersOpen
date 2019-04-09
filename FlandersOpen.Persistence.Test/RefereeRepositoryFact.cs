using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Persistence.Test
{
    public class RefereeRepositoryFact : BaseRepositoryFact<Referee>
    {
        protected override Referee BuildItem()
        {
            return Referee.Build("test", new ShortName("T"));
        }
    }
}