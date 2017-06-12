using System;
using System.Text.RegularExpressions;

namespace MatchCount
{
    public class Program
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            Console.WriteLine(matches.Count);
        }
    }
}
