using System;
using System.Collections.Generic;

namespace Palindromes
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            var palindromeWords = new SortedSet<string>();

            foreach (var word in text)
            {
                if(IsPalindrome(word))
                {
                    palindromeWords.Add(word);
                }
            }

            Console.WriteLine("[{0}]", string.Join(", ", palindromeWords));
        }

        private static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                    return false;
            }

            return true;
        }
    }
}
