using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    public class Rage_Quit
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var resultMessage = new StringBuilder();

            var regex = new Regex(@"(\D+)(\d+)");
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                var word = match.Groups[1].Value;
                var count = int.Parse(match.Groups[2].Value);

                resultMessage.Append(GetRepeatedWord(word, count));
            }

            Console.WriteLine("Unique symbols used: {0}", resultMessage.ToString().Distinct().Count());
            Console.WriteLine(resultMessage.ToString());
        }

        public static string GetRepeatedWord(string word, int count)
        {
            var resultWord = string.Empty;

            for (int i = 0; i < count; i++)
            {
                resultWord += word.ToUpper();
            }

            return resultWord;
        }
    }
}
