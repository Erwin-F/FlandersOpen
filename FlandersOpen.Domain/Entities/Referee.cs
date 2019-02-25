using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;
using System;

namespace FlandersOpen.Domain.Entities
{
    public class Referee : Entity
    {
        private Referee() { }

        protected Referee(string name, ShortName shortName)
        {
            Id = Guid.NewGuid();
            ModificationDate = DateTime.Now;
            Name = name;
            ShortName = shortName;
        }

        public string Name { get; private set; }
        public ShortName ShortName { get; private set; }

        public static Referee Build(string name, ShortName shortName)
        {
            return new Referee(name, shortName);
        }

        public void Update(string name, ShortName shortName)
        {
            Name = name;
            ShortName = ShortName;
        }
    }
}
