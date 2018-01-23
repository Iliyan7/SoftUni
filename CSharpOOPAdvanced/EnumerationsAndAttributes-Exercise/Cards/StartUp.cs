using System;

namespace Cards
{
    class StartUp
    {
        public static void Main()
        {
            var doc = new DeckOfCards();
            doc.GenerateAllCards();
        }
    }
}
