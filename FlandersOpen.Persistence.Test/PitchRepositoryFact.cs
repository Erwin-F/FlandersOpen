using FlandersOpen.Domain.Entities;

namespace FlandersOpen.Persistence.Test
{
    public class PitchRepositoryFact : BaseRepositoryFact<Pitch>
    {
        protected override Pitch BuildItem()
        {
            return Pitch.Build("Test", 1, 1);
        }
    }
}    