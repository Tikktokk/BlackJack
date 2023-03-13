using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Hand
    {
        private readonly List<Card> _cards;

        public int Score { get
            {

                var score = _cards
                    .Where(c => c.Rank != 1)
                    .Sum(c => c.Rank);

                var totalAces = _cards.Count(c => c.Rank == 1);

                for(int remainingAces = totalAces; remainingAces > 0; --remainingAces)
                {
                    var canAddUpperAceValue = score
                        + BlackjackRules.LowerAceValue * (remainingAces - 1)
                        + BlackjackRules.UpperAceValue
                        <= BlackjackRules.MaxScore;

                    score += canAddUpperAceValue
                        ? BlackjackRules.UpperAceValue
                        : BlackjackRules.LowerAceValue;
                }

                return score;
            }
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public Hand()
        {
            _cards = new List<Card>();
        }
    }
}
