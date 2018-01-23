using System;
using System.Text.RegularExpressions;

namespace _04TreasureMap
{
    class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var instructionPattern = @"(?<=!|#)[^!#]*?([a-zA-Z]{4})[^!#]+(?<!\d)(\d{3})-(\d\d\d\d|\d\d\d\d\d\d)(?!\d)[^!#]*(?=!|#)";

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var instructionBlockMatches = Regex.Matches(input, instructionPattern);
                var instructionBlock = instructionBlockMatches[instructionBlockMatches.Count / 2];

                Console.WriteLine($"Go to str. {instructionBlock.Groups[1].Value} {instructionBlock.Groups[2].Value}. Secret pass: {instructionBlock.Groups[3].Value}.");
            }
        }
    }
}
