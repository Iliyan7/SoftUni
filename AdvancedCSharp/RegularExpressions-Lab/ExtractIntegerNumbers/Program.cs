using System;
using System.Text.RegularExpressions;

namespace ExtractIntegerNumbers
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = @"\d+";

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
