using System;

namespace Letters_Change_Numbers
{
    public class Letters_Change_Numbers
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var result = 0D;

            for (int i = 0; i < words.Length; i++)
            {
                result += GetNakovSumOfWord(words[i]);
            }

            Console.WriteLine("{0:F2}", result);
        }

        public static double GetNakovSumOfWord(string word)
        {
            var firstLetter = word[0];
            var firstLetterPosition = firstLetter - (char.IsUpper(firstLetter) ? '@' : '`');
            var num = int.Parse(word.Substring(1, word.Length - 2));
            var lastLetter = word[word.Length - 1];
            var lastLetterPosition = lastLetter - (char.IsUpper(lastLetter) ? '@' : '`');

            var result = 0D;

            if (char.IsUpper(firstLetter))
            {
                result = num / (double)firstLetterPosition;
            }
            else
            {
                result = num * (double)firstLetterPosition;
            }

            if (char.IsUpper(lastLetter))
            {
                result -= lastLetterPosition;
            }
            else
            {
                result += lastLetterPosition;
            }

            return result;
        }
    }
}
