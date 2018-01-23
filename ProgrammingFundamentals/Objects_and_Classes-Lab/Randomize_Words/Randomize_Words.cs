using System;
using System.Linq;

namespace Randomize_Words
{
    public class Randomize_Words
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split();
            string[] newWordsList = new string[words.Length];
            string[] alreadyUsedWords = new string[words.Length];

            Random rnd = new Random();
            string word = String.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                do
                {
                    word = words[GetRandomNum(rnd, 0, words.Length)];

                } while (alreadyUsedWords.Contains(word));


                newWordsList[i] = alreadyUsedWords[i] = word;
            }

            foreach (var item in newWordsList)
            {
                Console.WriteLine(item);
            }
        }

        public static int GetRandomNum(Random rnd, int start, int end)
        {
            return rnd.Next(0, end);
        }
    }
}
