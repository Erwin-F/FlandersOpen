using FlandersOpen.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlandersOpen.Domain.Entities
{
    public class Gameslot : Entity
    {
        public Team Team { get; set; }

        private Gameslot() {}

        private Gameslot(Team team)
        {
            Team = team;
        }

        internal bool ContainsTeam(Team team)
        {
            return Team == team;
        }

        internal static Gameslot Build(Team team)
        {
            return new Gameslot(team);
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
