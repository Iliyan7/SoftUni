using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Regeh
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"\[[\x00-\x1F\x21-\x5A\x5C-\x7F]+?<(\d+)REGEH(\d+)>[\x00-\x1F\x21-\x5C\x5E-\x7F]+?\]";

            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            var indexes = new List<int>();
            var chars = new List<char>();

            foreach (Match match in matches)
            {
                for (int i = 1; i < match.Groups.Count; i++)
                {
                    var currentIndex = int.Parse(match.Groups[i].Value);
                   
                    var sumIndexes = indexes.Sum();
                    var newIndex = sumIndexes + currentIndex;

                    if(newIndex >= input.Length)
                    {
                        newIndex %= input.Length;
                        newIndex += 1;
                    }

                    indexes.Add(currentIndex);
                    chars.Add(input[newIndex]);
                }
            }

            Console.WriteLine(string.Join("", chars));
        }
    }
}
