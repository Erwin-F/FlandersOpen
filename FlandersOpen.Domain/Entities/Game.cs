using System;
using System.Collections.Generic;
using System.Linq;
using FlandersOpen.Domain.Exceptions;
using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Domain.Entities
{
    public class Game : Entity
    {
        private Game() { }

        public int Number { get; private set; }

        public Competition Competition { get; private set; }
        public Referee Referee { get; private set; }                

        public List<Gameslot> Gameslots { get; private set; }


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

            if (Gameslots.Count == 2)
                throw new GameslotsAlreadyFullException($"Impossible to add Team {team.Name} ({team.Id}) to Game with id: {Id}  - number: {Number}");

            if (Gameslots.Any(g => g.ContainsTeam(team)))
                throw new GameslotWithSameTeamException($"Impossible to add Team {team.Name} ({team.Id}) to Game with id: {Id}  - number: {Number}");

            var gameslot = Gameslot.Build(team);
            Gameslots.Add(gameslot);
        }
    }
}