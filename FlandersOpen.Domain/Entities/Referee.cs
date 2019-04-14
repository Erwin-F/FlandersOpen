using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace FlandersOpen.Domain.Entities
{
    public class Referee : Entity
    {
        private Referee() { }

        protected Referee(string name, ShortName shortName)
        {
            Id = Guid.NewGuid();
            Name = name;
            ShortName = shortName;
        }

        public string Name { get; private set; }
        public ShortName ShortName { get; private set; }

        public List<Game> Games { get; private set; }

        public static Referee Build(string name, ShortName shortName)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (shortName == null)
                throw new ArgumentNullException(nameof(shortName));

            return new Referee(name, shortName);
        }

        public void Update(string name, ShortName shortName)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            ShortName = shortName ?? throw new ArgumentNullException(nameof(shortName));
        }
    }
}
