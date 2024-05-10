namespace ShuffleDeckOfCards
{
    public enum CardValue
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 13,
        King = 14
    }

    public enum CardFace
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public class Card
    {
        public CardFace Face
        {
            get;
            set;
        }

        public CardValue Value
        {
            get;
            set;
        }
    }
}
