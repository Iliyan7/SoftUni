using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"\+359( |-)\d\1\d{3}\1\d{4}\b";

            while (input != "end")
            {
                var regex = new Regex(pattern);
                var match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
