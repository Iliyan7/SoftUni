using System;

namespace CharacterMultiplier
{
    public class Program
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split(' ');

            var minLen = Math.Min(words[0].Length, words[1].Length);
            var maxLen = Math.Max(words[0].Length, words[1].Length);
            var biggestWordIndex = words[0].Length > words[1].Length ? 0 : 1;

            var sum = 0;

            for (int i = 0; i < minLen; i++)
            {
                sum += words[0][i] * words[1][i];
            }

            for (int i = minLen; i < maxLen; i++)
            {
                sum += words[biggestWordIndex][i];
            }

            Console.WriteLine(sum);
        }
    }
}
