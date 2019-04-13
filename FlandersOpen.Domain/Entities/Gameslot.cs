using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlandersOpen.Domain.Entities
{
    public class Gameslot : Entity
    {
        public Team Team { get; private set; }

        public Score Score { get; private set; }
        

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

        internal void UpdateScore(Score score)
        {
            Score = score;
        }
    }
}