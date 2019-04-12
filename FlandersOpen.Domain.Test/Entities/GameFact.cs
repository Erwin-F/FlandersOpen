using FlandersOpen.Domain.Entities;
using System;
using Xunit;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Domain.Test
{
    public class GameFact
    {
        private Competition _competition;

        public GameFact()
        {
            _competition = Competition.Build("test", new ShortName("T"), new ColorString("ffffff"));
        }

        [Fact]
        public void CreateGameWithNullCompetitionThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Game.Build(null, 1));
        }

        [Fact]
        public void CreateGameHasEmptyGameslots()
        {
            
            var game = Game.Build(_competition, 1);

            Assert.Empty(game.Gameslots);
        }

        [Fact]
        public void AddGameslotWithNullTeamThrowsAnException()
        {
            var game = Game.Build(_competition, 1);

            Assert.Throws<ArgumentNullException>(() => game.AddTeam(null));
        }

        [Fact]
        public void AddGameslotAdds1Slot()
        {
            var game = Game.Build(_competition, 1);
            var team = Team.Build(_competition, null, "team");

            game.AddTeam(team);

            Assert.Single(game.Gameslots);
        }
    }
}
