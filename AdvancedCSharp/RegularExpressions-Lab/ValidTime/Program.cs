using System;
using System.Text.RegularExpressions;

namespace ValidTime
{
    public class Program
    {
        public static void Main()
        {
            var time = Console.ReadLine();
            var pattern = @"^((0[0-9])|(1[01])):[0-5][0-9]:[0-5][0-9]\s[AP]M$";

            while (time != "END")
            {
                var regex = new Regex(pattern);
                var match = regex.Match(time);

                Console.WriteLine(match.Success ? "valid" : "invalid");

                time = Console.ReadLine();
            }
        }
    }
}