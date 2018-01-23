using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Word_Count
{
    public class Word_Count
    {
        public static void Main()
        {
            string wordsFile = "words.txt";
            string textFile = "text.txt";
            string outputFile = "output.txt";

            string[] words = File.ReadAllText(wordsFile).Split(' ');

            char[] separators = new char[] { '-', ' ', ',', '.', '?', '!', '\r', '\n' };
            string[] wordsFromTextFile = File.ReadAllText(textFile).ToLower().Replace("…", " ").Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> containedWords = new Dictionary<string, int>();

            foreach (string word in wordsFromTextFile)
            {
                if (words.Contains(word))
                {
                    if (!containedWords.ContainsKey(word))
                        containedWords.Add(word, 0);

                    containedWords[word]++;
                }
            }

            List<string> orderedContainedWords = new List<string>();

            foreach (var pair in containedWords.OrderByDescending(x => x.Value))
            {
                string line = string.Format("{0} - {1}", pair.Key, pair.Value);
                orderedContainedWords.Add(line);
            }

            File.WriteAllLines(outputFile, orderedContainedWords);
        }
    }
}
