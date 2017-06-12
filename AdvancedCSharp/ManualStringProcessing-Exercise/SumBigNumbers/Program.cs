using System;
using System.Collections.Generic;
using System.Linq;

namespace SumBigNumbers
{
    public class Program
    {
        public static void Main()
        {
            var firstNum = Console.ReadLine()
                .Select(x => int.Parse(char.ToString(x)))
                .ToList();

            var secondNum = Console.ReadLine()
                .Select(x => int.Parse(char.ToString(x)))
                .ToList();

            EqualizeNumbers(firstNum, secondNum);

            var reminder = 0;
            var result = new List<int>();

            for (int i = firstNum.Count - 1; i >= 0; i--)
            {
                int sum = firstNum[i] + secondNum[i] + reminder;

                if (sum < 10)
                {
                    result.Add(sum);
                    reminder = 0;
                }
                else
                {
                    result.Add(sum % 10);
                    reminder = 1;
                }
            }

            if (reminder == 1)
            {
                result.Insert(result.Count, 1);
            }

            result.Reverse();

            Console.WriteLine(string.Join("", result).TrimStart('0'));
        }

        private static void EqualizeNumbers(List<int> n1, List<int> n2)
        {
            if (n1.Count == n2.Count)
                return;

            var zerosToInstert = Math.Abs(n1.Count - n2.Count);

            if (n1.Count < n2.Count)
            {
                while (zerosToInstert-- > 0)
                {
                    n1.Insert(0, 0);
                }
            }
            else
            {
                while (zerosToInstert-- > 0)
                {
                    n2.Insert(0, 0);
                }
            }
        }
    }
}
