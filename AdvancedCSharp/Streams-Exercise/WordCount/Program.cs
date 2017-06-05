using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class Program
    {
        public static void Main()
        {
            using (var wordsReader = new StreamReader("../../words.txt"))
            using (var textReader = new StreamReader("../../text.txt"))
            using (var resultWriter = new StreamWriter("../../result.txt"))
            {
                var wordsCount = new Dictionary<string, int>();
                var line = wordsReader.ReadLine();

                while (line != null)
                {
                    wordsCount.Add(line, 0);
                    line = wordsReader.ReadLine();
                }

                var text = textReader
                    .ReadToEnd()
                    .ToLower()
                    .Split(new char[] { '.', ',', '?', '!', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in text)
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        wordsCount[word]++;
                    }
                }

                foreach (var word in wordsCount.OrderByDescending(x => x.Value))
                {
                    resultWriter.WriteLine("{0} - {1}", word.Key, word.Value);
                }
            }
        }
    }
}
