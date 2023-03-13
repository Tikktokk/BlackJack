using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        private static readonly Random _random;

        private readonly Queue<Card> _cards;

        static Deck()
        {
            _random = new Random();
        }

        public Deck()
        {
            _cards = new Queue<Card>();

            var cardList = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    cardList.Add(new Card(suit, i));
                }
            }

            _cards = new Queue<Card>(cardList.OrderBy(_ => _random.Next()));
        }

        public int Size
        {
            get {
                return _cards.Count;
            }
        }

        public Card DrawCard()
        {
            return _cards.Any()
                ? _cards.Dequeue()
                : null;
        }
    }
}
