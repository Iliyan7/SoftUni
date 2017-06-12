using System;
using System.Text.RegularExpressions;

namespace NonDigitCount
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = @"\D";

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            Console.WriteLine("Non-digits: {0}", matches.Count);
        }
    }
}
