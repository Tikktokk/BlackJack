using System;

namespace BlackJack
{
    class Program
    {
        private static Deck Deck;
        private static Hand PlayerHand;
        private static Hand DealerHand;

        static Card DrawCard()
        {
            if (Deck.Size == 0)
            {
                Deck = new Deck();
            }

            return Deck.DrawCard();
        }

        static void HitDealer()
        {
            var card = DrawCard();
            DealerHand.Add(card);
            var total = DealerHand.Score;
            Console.WriteLine("Dealer hit with {0}. Dealer's total is {1}", card, total);
        }

        static void HitPlayer()
        {
            var card = DrawCard();
            PlayerHand.Add(card);
            var total = PlayerHand.Score;
            Console.WriteLine("Hit with {0}. Your total is {1}", card, total);
        }

        static void Lose()
        {
            Console.WriteLine("Dealer wins!");
        }

        static void Draw()
        {
            Console.WriteLine("It's a tie!");
        }

        static void Win()
        {
            Console.WriteLine("You win!");
        }

        static void PlayerInput()
        {
            while (PlayerHand.Score < BlackjackRules.MaxScore)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    HitPlayer();
                }
                else if (read == "Stand")
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Deck = new Deck();
            PlayerHand = new Hand();
            DealerHand = new Hand();

            HitDealer();

            PlayerInput();

            if (PlayerHand.Score > BlackjackRules.MaxScore)
            {
                Lose();
                return;
            }

            while (DealerHand.Score < BlackjackRules.DealerDrawLimit)
            {
                HitDealer();
            }

            if (DealerHand.Score > BlackjackRules.MaxScore || DealerHand.Score < PlayerHand.Score)
            {
                Win();
                return;
            }

            if (DealerHand.Score > PlayerHand.Score)
            {
                Lose();
                return;
            }

            Draw();
        }
    }
}
