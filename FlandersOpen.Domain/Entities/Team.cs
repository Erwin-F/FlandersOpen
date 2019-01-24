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
        }

        public Guid CompetitionId { get; private set; }
        public Guid CountryId { get; private set; }

        public string Name { get; private set; }

        //TODO not sure if this makes sense
        //public static Team Add(Guid competitionId, Guid countryId, string name)
        //{
        //    return new Team(competitionId, countryId, name);
        //}
    }
}
