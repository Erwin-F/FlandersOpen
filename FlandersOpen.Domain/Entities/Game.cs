using System;
using System.Collections.Generic;
using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Domain.Entities
{
    public class Game : Entity
    {
        private Game() { }

        public int Number { get; set; }

        public Competition Competition { get; set; }
        public Referee Referee { get; set; }                

        public List<Gameslot> Gameslots { get; set; }


        protected Game(Competition competition, int number)
        {
            Id = Guid.NewGuid();
            Competition = competition;
            Number = number;

            Gameslots = new List<Gameslot>();
        }

        public static Game Build(Competition competition, int number)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));

            return new Game(competition, number);
        }

        public void AssignReferee(Referee referee)
        {
            Referee = referee ?? throw new ArgumentNullException(nameof(referee));
        }

        public void AddTeam(Team team)
        {
            if (team == null)
                throw new ArgumentNullException(nameof(team));

        }
    }
}

/*
    Game:
    - Competition
    - Referee
    - GameNr (Once games in place / possibility to rearrange nrs)

    - Gameslot (2)
        - Team Id
        - Fairplay points

        Score:
        - Scored
        - Against
        - Forfeited
        - Yellow Cards
        - Red Cards
        - Points (calculated)

    


*/