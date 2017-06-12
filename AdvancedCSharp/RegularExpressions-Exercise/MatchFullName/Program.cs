using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"[A-Z][a-z]{1,} [A-Z][a-z]{1,}";

            while(input != "end")
            {
                var regex = new Regex(pattern);
                var match = regex.Match(input);

                if(match.Success)
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
