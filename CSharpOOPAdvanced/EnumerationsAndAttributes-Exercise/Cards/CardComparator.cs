using System;

namespace Cards
{
    public class CardComparator
    {
        public void PrintGreaterCard(string firstCardRank, string firstCardSuit, string secondCardRank, string secondCardSuit)
        {
            var firstCard = new Card((CardSuit)Enum.Parse(typeof(CardSuit), firstCardSuit), (CardRank)Enum.Parse(typeof(CardRank), firstCardRank));
            var secondCard = new Card((CardSuit)Enum.Parse(typeof(CardSuit), secondCardSuit), (CardRank)Enum.Parse(typeof(CardRank), secondCardRank));

            if (firstCard.CompareTo(secondCard) > 0)
            {
                Console.WriteLine(firstCard);
            }
            else
            {
                Console.WriteLine(secondCard);
            }
        }
    }
}
