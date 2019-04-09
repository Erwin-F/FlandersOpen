using System;
using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Domain.Entities
{
    public class Game : Entity
    {
        private Game() { }

        public Guid CompetitionId { get; set; }
        public Guid RefereeId { get; set; }

        public Competition Competition { get; set; }
        public Referee Referee { get; set; }                


        protected Game(Guid competitionId)
        {
            Id = Guid.NewGuid();
            //TODO
        }

        public static Game Build(Guid competitionId)
        {
            return new Game(competitionId);
        }
    }
}