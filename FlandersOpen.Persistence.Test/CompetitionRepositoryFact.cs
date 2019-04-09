using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Persistence.Test
{
    public class CompetitionRepositoryFact : BaseRepositoryFact<Competition>
    {
        protected override Competition BuildItem()
        {
            return Competition.Build("Test", new ShortName("T"), new ColorString("FFFFFF"));
        }
    }
}
