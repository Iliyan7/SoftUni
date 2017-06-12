using System;
using System.Text.RegularExpressions;

namespace VowelCount
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = "[AEIOUYaeiouy]";

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            Console.WriteLine("Vowels: {0}", matches.Count);
        }
    }
}
