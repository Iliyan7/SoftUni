using System;
using System.Text.RegularExpressions;

namespace ExtractEmail
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = @"(?<=\s)[a-zA-Z0-9][\w.-]*[a-zA-Z0-9]@[a-zA-Z][a-zA-Z-]*[a-zA-Z](\.[a-zA-Z][a-zA-Z-]*[a-zA-Z])+(?=\b)";

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
