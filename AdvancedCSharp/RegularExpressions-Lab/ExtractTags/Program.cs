using System;
using System.Text.RegularExpressions;

namespace ExtractTags
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = @"<.+?>";

            while (text != "END")
            {
                var regex = new Regex(pattern);
                var matches = regex.Matches(text);

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }

                text = Console.ReadLine();
            }
        }
    }
}