using System;
using System.Text.RegularExpressions;

namespace SeriesOfLetters
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"(.)\1+";

            var regex = new Regex(pattern);

            Console.WriteLine(regex.Replace(input, "$1"));
        }
    }
}
