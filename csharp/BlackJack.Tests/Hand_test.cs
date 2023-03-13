using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Tests
{
    [TestFixture]
    public class Hand_test
    {

        [Test]
        public void AceTest()
        {
            var hand = new Hand();
            hand.Add(new Card(Suit.Hearts, 1));
            hand.Add(new Card(Suit.Hearts, 1));
            hand.Add(new Card(Suit.Hearts, 1));

            Assert.AreEqual(13, hand.Score);
        }
    }
}
