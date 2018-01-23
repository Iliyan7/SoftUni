using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split(new char[] { ' ', '.', ',', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var palindromeWords = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == ReverseString(words[i]))
                    palindromeWords.Add(words[i]);
            }

            Console.WriteLine(string.Join(", ", palindromeWords.Distinct().OrderBy(x => x)));
        }

        public static string ReverseString(string str)
        {
            var sb = new StringBuilder(str.Length);

            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}
