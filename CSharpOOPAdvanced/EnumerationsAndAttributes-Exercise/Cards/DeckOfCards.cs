using System;

namespace Cards
{
    public class DeckOfCards
    {
        public void GenerateAllCards()
        {
            var cardSuits = Enum.GetNames(typeof(CardSuit));
            var cardRanks = Enum.GetNames(typeof(CardRank));

            foreach (var cardSuit in cardSuits)
            {
                foreach (var cardRank in cardRanks)
                {
                    Console.WriteLine(cardRank + " of " + cardSuit);
                }
            }
        }
    }
}