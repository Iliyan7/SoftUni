using System;

namespace Character_Multiplier
{
    public class Character_Multiplier
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(' ');

            var minLen = Math.Min(words[0].Length, words[1].Length);
            var maxLen = Math.Max(words[0].Length, words[1].Length);
            var biggestWord = words[0].Length > words[1].Length ? 0 : 1;

            var result = 0;

            for (int i = 0; i < minLen; i++)
            {
                result += words[0][i] * words[1][i];
            }

            for (int i = minLen; i < maxLen; i++)
            {
                result += words[biggestWord][i];
            }

            Console.WriteLine(result);
        }
    }
}
