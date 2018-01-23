using System;
using System.Collections.Generic;
using System.Linq;

namespace Hands_of_Cards
{
    public class Hands_of_Cards
    {
        public static void Main()
        {
            char[] separators = new char[] { ',', ' ' };
            string[] nameAndCards = Console.ReadLine().Split(':');

            if (nameAndCards.Length == 1)
                return;

            List<string> currentCards = nameAndCards[1].Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            Dictionary<string, List<string>> totalCards = new Dictionary<string, List<string>>();

            while (nameAndCards[0] != "JOKER")
            {
                string name = nameAndCards[0];

                if (!totalCards.ContainsKey(name))
                    totalCards.Add(name, currentCards);
                else
                    totalCards[name].AddRange(currentCards);

                nameAndCards = Console.ReadLine().Split(':');

                if(nameAndCards[0] != "JOKER")
                    currentCards = nameAndCards[1].Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            Dictionary<string, int> totalPower = new Dictionary<string, int>();

            foreach (KeyValuePair<string, List<string>> pair in totalCards)
            {
                totalPower[pair.Key] = GetHandPower(pair.Value.Distinct().ToList());
            }

            foreach (KeyValuePair<string, int> pair in totalPower)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }

        public static int GetHandPower(List<string> cards)
        {
            int power = 0;

            for (int i = 0; i < cards.Count(); i++)
            {
                int cardValue, cardMultiplier = 0;

                ReplaceCards(cards[i], out cardValue, out cardMultiplier);
                power += cardValue * cardMultiplier;
            }

            return power;
        }

        public static void ReplaceCards(string card, out int value, out int multiplier)
        {
            if (card[0] == '1' && card[1] == '0')
            {
                value = 10;
                multiplier = GetMultiplier(card[2]);
                return;
            }

            switch (card[0])
            {
                case 'J': value = 11; break;
                case 'Q': value = 12; break;
                case 'K': value = 13; break;
                case 'A': value = 14; break;
                default: value = int.Parse(card[0].ToString()); break;
            }

            multiplier = GetMultiplier(card[1]);
        }

        public static int GetMultiplier(char letter)
        {
            int multiplier = 0;

            switch (letter)
            {
                case 'C': multiplier = 1; break;
                case 'D': multiplier = 2; break;
                case 'H': multiplier = 3; break;
                case 'S': multiplier = 4; break;
                default: multiplier = 1; break;
            }

            return multiplier;
        }
    }
}
