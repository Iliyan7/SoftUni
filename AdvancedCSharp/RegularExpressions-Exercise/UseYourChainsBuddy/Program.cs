using System;
using System.Text;
using System.Text.RegularExpressions;

namespace UseYourChainsBuddy
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"<p>(.+?)<\/p>";

            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            var sb = new StringBuilder();

            foreach (Match match in matches)
            {
                var replacedMatch = Regex.Replace(match.Groups[1].Value, "[^a-z0-9]+", " ");

                foreach (var ch in replacedMatch)
                {
                    var decryptChar = ch;

                    if ('a' <= ch && ch <= 'm')
                    {
                        decryptChar = (char)(ch + ('z' - 'm'));
                    }
                    else if('n' <= ch && ch <= 'z')
                    {
                        decryptChar = (char)(ch - ('z' - 'm'));
                    }

                    sb.Append(decryptChar);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
