using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_initialized : Scenario
    {
        private Deck _deck;
        public override void When()
        {
            _deck = new Deck();
        }

        [Test]
        public void Should_have_52_cards()
        {
            Assert.AreEqual(52, _deck.Size);
        }

        [Test]
        public void Should_have_4_distinct_suits()
        {
            var queue = new Queue<Card>();
            while(_deck.Size > 0)
            {
                queue.Enqueue(_deck.DrawCard());
            }
            Assert.AreEqual(4, queue.Select(x => (int)x.Suit).Distinct().ToList().Count);
        }
    }
}
