using System;
using System.Text.RegularExpressions;

namespace ValidUsernames
{
    public class Program
    {
        public static void Main()
        {
            var username = Console.ReadLine();
            var pattern = @"^[\w-]{3,16}$";

            while (username != "END")
            {
                var regex = new Regex(pattern);
                var match = regex.Match(username);

                Console.WriteLine(match.Success ? "valid" : "invalid");

                username = Console.ReadLine();
            }
        }
    }
}