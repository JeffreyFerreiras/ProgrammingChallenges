using System;
using System.Collections.Generic;
using System.Text;

namespace ShuffleDeckOfCards
{
    public class Deck
    {
        private readonly static object _syncLock = new object();
        private readonly static Random _random = new Random();

        public List<Card> Cards
        {
            get;
            private set;
        }

        public Deck()
        {
            Cards = new List<Card>();

            foreach (CardFace enumValue in typeof(CardFace).GetEnumValues())
            {
                Cards.AddRange(this.BuildCardSuite(enumValue));
            }
        }

        private IEnumerable<Card> BuildCardSuite(CardFace suite)
        {
            foreach (CardValue enumValue in typeof(CardValue).GetEnumValues())
            {
                yield return new Card()
                {
                    Face = suite,
                    Value = enumValue
                };
            }
        }

        public void Display()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine(string.Format("{0}: {1}", card.Face, card.Value));
            }
        }

        private int GetRandomIndex()
        {
            int num;
            lock (_syncLock)
            {
                int num1 = _random.Next(0, Cards.Count);
                num = num1;
            }
            return num;
        }

        public void Shuffle()
        {
            InternalShuffle(0);
        }

        private void InternalShuffle(int shuffleCount)
        {
            for (int i = 0; i < this.Cards.Count; i++)
            {
                Swap(GetRandomIndex(), GetRandomIndex());
            }

            if (shuffleCount < 3) InternalShuffle(++shuffleCount);
        }

        private void Swap(int left, int right)
        {
            Card temp = Cards[left];
            Cards[left] = Cards[right];
            Cards[right] = temp;
        }
    }
}