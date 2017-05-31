using System;
using System.Collections.Generic;

namespace HandsOfCards
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var drawedCards = new Dictionary<string, HashSet<string>>();

            while(input != "JOKER")
            {
                var args = input.Split(':');

                var name = args[0];
                var cards = args[1].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (drawedCards.ContainsKey(name))
                {
                    foreach (var card in cards)
                        drawedCards[name].Add(card);
                }
                else
                {
                    var set = new HashSet<string>();

                    foreach (var card in cards)
                    {
                        set.Add(card);
                    }

                    drawedCards.Add(name, set);
                }

                input = Console.ReadLine();
            }

            foreach (var playerCards in drawedCards)
            {
                Console.WriteLine("{0}: {1}", playerCards.Key, GetTotalCardsValue(playerCards.Value));
            }
        }

        private static int GetTotalCardsValue(HashSet<string> cards)
        {
            var value = 0;

            foreach (var card in cards)
            {
                value += getCardValue(card);
            }

            return value;
        }

        private static int getCardValue(string card)
        {
            var value = 0;
            var multiplier = 1;

            switch (card.Substring(card.Length - 1))
            {
                case "D": multiplier = 2; break;
                case "H": multiplier = 3; break;
                case "S": multiplier = 4; break;
            }

            switch (card[0])
            {
                case '2': value = 2 * multiplier; break;
                case '3': value = 3 * multiplier; break;
                case '4': value = 4 * multiplier; break;
                case '5': value = 5 * multiplier; break;
                case '6': value = 6 * multiplier; break;
                case '7': value = 7 * multiplier; break;
                case '8': value = 8 * multiplier; break;
                case '9': value = 9 * multiplier; break;
                case '1': if (card[1] == '0') value = 10 * multiplier; break;
                case 'J': value = 11 * multiplier; break;
                case 'Q': value = 12 * multiplier; break;
                case 'K': value = 13 * multiplier; break;
                case 'A': value = 14 * multiplier; break;
            }

            return value;
        }
    }
}
