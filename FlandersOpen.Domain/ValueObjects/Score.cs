using FlandersOpen.Domain.SeedWork;
using System.Collections.Generic;

namespace FlandersOpen.Domain.ValueObjects
{
    public class Score : ValueObject
    {
        private Score() { }

        public int FairplayPoints { get; private set; }
        public int Scored { get; private set; }
        public int Against { get; private set; }
        public bool Forfeited { get; private set; }
        public int YellowCards { get; private set; }
        public int RedCards { get; private set; }

        public int Points => CalculatePoints();

        public Score(int fairplayPoints, int scored, int against, bool forfeited, bool wonbyForfeit, int yellowcards, int redcards)
        {
            FairplayPoints = fairplayPoints;

            if (forfeited && wonbyForfeit)
            {
                Scored = 0;
                Against = 0;
            }            
            else if (forfeited)
            {
                Scored = 0;
                Against = 21;
            }
            else if (wonbyForfeit)
            {
                Scored = 21;
                Against = 0;
            }
            else
            {
                Scored = scored;
                Against = against;
            }

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