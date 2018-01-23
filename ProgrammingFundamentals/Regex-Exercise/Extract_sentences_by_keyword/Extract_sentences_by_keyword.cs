using System;
using System.Text.RegularExpressions;

namespace Extract_sentences_by_keyword
{
    public class Extract_sentences_by_keyword
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var sentences = Console.ReadLine()
                .Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var pattern = string.Format(@"\b{0}\b", word);
            var regex = new Regex(pattern);

            for (int i = 0; i < sentences.Length; i++)
            {
                var sen = sentences[i].Trim();

                if (regex.IsMatch(sen))
                    Console.WriteLine(sen);
            }
        }
    }
}
