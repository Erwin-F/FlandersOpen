using FlandersOpen.Domain.SeedWork;
using System;

namespace FlandersOpen.Domain.Entities
{
    public class Team : Entity
    {
        private Team() { }

        protected Team(Competition competition, Country country, string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Competition = competition;
            Country = country ?? null;
        }

        public string Name { get; private set; }

        public Competition Competition { get; private set; }
        public Country Country { get; private set; }

        public static Team Build(Competition competition, Country country, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (competition == null)
                throw new ArgumentNullException(nameof(competition));

            return new Team(competition, country, name);
        }

        public void Update(Competition competition, Country country, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));


            Name = name;
            Competition = competition ?? throw new ArgumentNullException(nameof(competition));
            Country = country ?? null;
        }
    }
}
