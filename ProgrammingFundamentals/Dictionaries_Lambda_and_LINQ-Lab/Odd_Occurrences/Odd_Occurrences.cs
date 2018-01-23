using System;
using System.Collections.Generic;

namespace Odd_Occurrences
{
    public class Odd_Occurrences
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().ToLower().Split(' ');

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!counts.ContainsKey(word))
                {
                    counts[word] = 0;
                }

                counts[word]++;
            }

            List<string> result = new List<string>();

            foreach (KeyValuePair<string, int> pair in counts)
            {
                if (pair.Value % 2 == 1)
                {
                    result.Add(pair.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
