using System;
using System.Text.RegularExpressions;

namespace SentenceExtractor
{
    public class Program
    {
        public static void Main()
        {
            var keyword = Console.ReadLine();
            var text = Console.ReadLine();
            var sentences = Regex
                .Split(text, @"(?<=[.!?]) ");

            var pattern = string.Format(@".*?\b{0}\b.*?[.!?]", keyword);

            foreach (var sentence in sentences)
            {
                if(Regex.IsMatch(sentence, pattern))
                {
                    Console.WriteLine(sentence);
                }
            }
        }
    }
}
