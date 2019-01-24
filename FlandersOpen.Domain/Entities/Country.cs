using FlandersOpen.Domain.SeedWork;

namespace FlandersOpen.Domain.Entities
{
    public class Country : Entity
    {
        private Country() { }

        public string Name { get; private set; }
        public string Path { get; private set; }
    }
}
