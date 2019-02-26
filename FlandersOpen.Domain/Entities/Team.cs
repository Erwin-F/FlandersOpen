using FlandersOpen.Domain.SeedWork;
using System;

namespace FlandersOpen.Domain.Entities
{
    public class Team : Entity
    {
        private Team() { }

        protected Team(Guid competitionId, Guid countryId, string name)
        {
            Id = Guid.NewGuid();
            ModificationDate = DateTime.Now;
            Name = name;
            CompetitionId = competitionId;
            CountryId = countryId;
        }

        public Guid CompetitionId { get; private set; }
        public Guid CountryId { get; private set; }
        public string Name { get; private set; }

        public Competition Competition { get; private set; }
        public Country Country { get; private set; }

        public static Team Build(Guid competitionId, Guid countryId, string name)
        {
            return new Team(competitionId, countryId, name);
        }

        public void Update(Guid competitionId, Guid countryId, string name)
        {
            ModificationDate = DateTime.Now;
            Name = name;
            CompetitionId = competitionId;
            CountryId = countryId;
        }
    }
}
