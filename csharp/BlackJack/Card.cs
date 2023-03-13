namespace BlackJack
{
    public class Card
    {
        public Suit Suit { get; }

        public int Rank { get; }

        public Card(Suit suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string RankString { get
            {
                return Rank switch
                {
                    1 => "A",
                    11 => "J",
                    12 => "Q",
                    13 => "k",
                    _ => Rank.ToString()
                };
            }
        }

        public override string ToString()
        {
            return $"{RankString} {Suit}";
        }
    }
}
