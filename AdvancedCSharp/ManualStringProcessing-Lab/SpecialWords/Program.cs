using System;
using System.Collections.Generic;

namespace SpecialWords
{
    public class Program
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine()
                .Split(' ');

            var specialWordsCount = new Dictionary<string, int>();

            foreach (var word in specialWords)
            {
                specialWordsCount.Add(word, 0);
            }

            var text = Console.ReadLine()
              .Split(new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in text)
            {
                if(specialWordsCount.ContainsKey(word))
                    specialWordsCount[word]++;
            }

            foreach (var word in specialWordsCount)
            {
                Console.WriteLine("{0} - {1}", word.Key, word.Value);
            }
        }
    }
}
