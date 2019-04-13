using FlandersOpen.Domain.ValueObjects;
using Xunit;

namespace FlandersOpen.Domain.Test.ValueObjects
{
    public class ScoreFact
    {
        [Fact]
        public void WinGives3Points()
        {
            var score = new Score(0,5,0,false, false, 0,0);

            Assert.Equal(3, score.Points);
        }

        [Fact]
        public void LossGives1Point()
        {
            var score = new Score(0, 0, 5, false, false, 0, 0);

            Assert.Equal(1, score.Points);
        }

        [Fact]
        public void TieGives2Points()
        {
            var score = new Score(0, 5, 5, false, false, 0, 0);

            Assert.Equal(2, score.Points);
        }

        [Fact]
        public void ForfeitGives0Points()
        {
            var score = new Score(0, 5, 0, true, false, 0, 0);

            Assert.Equal(0, score.Points);
        }

        [Fact]
        public void WinByForfeitGives3Points()
        {
            var score = new Score(0, 5, 0, false, true, 0, 0);

            Assert.Equal(3, score.Points);
        }

        [Fact]
        public void ForfeitWonByForfeitGives0Points()
        {
            var score = new Score(0, 5, 0, true, true, 0, 0);

            Assert.Equal(0, score.Points);
        }

        [Fact]
        public void ForfeitGives0Scored()
        {
            var score = new Score(0, 5, 0, true, false, 0, 0);

            Assert.Equal(0, score.Scored);
        }

        [Fact]
        public void ForfeitGives21Against()
        {
            var score = new Score(0, 5, 0, true, false, 0, 0);

            Assert.Equal(21, score.Against);
        }


        [Fact]
        public void WonByForfeitGives0Against()
        {
            var score = new Score(0, 5, 0, false, true, 0, 0);

            Assert.Equal(0, score.Against);
        }

        [Fact]
        public void ForfeitedWonByForfeitGives0Scored()
        {
            var score = new Score(0, 5, 0, true, true, 0, 0);

            Assert.Equal(0, score.Scored);
        }

        [Fact]
        public void ForfeitedWonByForfeitGives0Against()
        {
            var score = new Score(0, 5, 0, true, true, 0, 0);

            Assert.Equal(0, score.Against);
        }
    }
}
