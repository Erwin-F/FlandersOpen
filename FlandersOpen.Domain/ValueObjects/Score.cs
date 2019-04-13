using FlandersOpen.Domain.SeedWork;
using System.Collections.Generic;

namespace FlandersOpen.Domain.ValueObjects
{
    public class Score : ValueObject
    {
        public int FairplayPoints { get; private set; }
        public int Scored { get; private set; }
        public int Against { get; private set; }
        public bool Forfeited { get; private set; }
        public int YellowCards { get; private set; }
        public int RedCards { get; private set; }

        public int Points => CalculatePoints();

        public Score(int fairplaypoints, int scored, int against, bool forfeited, int yellowcards, int redcards)
        {
            FairplayPoints = fairplaypoints;
            Scored = scored;
            Against = against;
            Forfeited = forfeited;
            YellowCards = yellowcards;
            RedCards = redcards;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FairplayPoints;
            yield return Scored;
            yield return Against;
            yield return Forfeited;
            yield return YellowCards;
            yield return RedCards;
        }

        private int CalculatePoints()
        {
            if (Forfeited)
            {
                return 0;
            }
            else if (Scored == Against)
            {
                return 2;
            } 
            else if (Scored > Against)
            {
                return 3;
            }
            else
            {
                return 1;
            }

        }
    }
}