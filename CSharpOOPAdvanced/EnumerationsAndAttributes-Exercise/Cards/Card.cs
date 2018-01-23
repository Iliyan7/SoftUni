using System;

namespace Cards
{
    public class Card : IComparable<Card>
    {
        public Card(CardSuit suit, CardRank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public CardSuit Suit { get; private set; }
        public CardRank Rank { get; private set; }

        public string Name()
        {
            return Enum.GetName(typeof(CardRank), this.Rank) + " of " + Enum.GetName(typeof(CardSuit), this.Suit);
        }

        public int Power()
        {
            return (int)Suit + (int)Rank;
        }

        public int CompareTo(Card other)
        {
            return this.Power() - other.Power();
        }

        public override string ToString()
        {
            return $"Card name: {this.Name()}; Card power: {this.Power()}";
        }

     
    }
}
