using System;

namespace LettersChangeNumbers
{
    public class Program
    {
        public static void Main()
        {
            var specialNumbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var sum = 0D;

            for (int i = 0; i < specialNumbers.Length; i++)
            {
                sum += GetNakovSumOfSpecialNumbers(specialNumbers[i]);
            }

            Console.WriteLine("{0:F2}", sum);
        }

        private static double GetNakovSumOfSpecialNumbers(string specialNumber)
        {
            var firstLetter = specialNumber[0];
            var firstLetterPosition = firstLetter - (char.IsUpper(firstLetter) ? '@' : '`');
            var number = int.Parse(specialNumber.Substring(1, specialNumber.Length - 2));
            var lastLetter = specialNumber[specialNumber.Length - 1];
            var lastLetterPosition = lastLetter - (char.IsUpper(lastLetter) ? '@' : '`');

            var sum = 0D;

            if (char.IsUpper(firstLetter))
            {
                sum += number / (double)firstLetterPosition;
            }
            else
            {
                sum += number * (double)firstLetterPosition;
            }

            if (char.IsUpper(lastLetter))
            {
                sum -= lastLetterPosition;
            }
            else
            {
                sum += lastLetterPosition;
            }

            return sum;
        }
    }
}
