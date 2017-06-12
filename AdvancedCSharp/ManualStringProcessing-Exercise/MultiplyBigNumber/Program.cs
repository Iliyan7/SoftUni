using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplyBigNumber
{
    public class Program
    {
        public static void Main()
        {
            var number = Console.ReadLine()
                .Select(x => int.Parse(char.ToString(x)))
                .ToList();

            var multiplier = byte.Parse(Console.ReadLine());

            if(multiplier == 0)
            {
                Console.WriteLine("0");
                return;
            }

            var reminder = 0;
            var result = new List<int>();

            for (int i = number.Count - 1; i >= 0; i--)
            {
                var sum = number[i] * multiplier + reminder;

                if (sum < 10)
                {
                    result.Add(sum);
                    reminder = 0;
                }
                else
                {
                    result.Add(sum % 10);
                    reminder = sum / 10;
                }
            }

            if (reminder > 0)
            {
                result.Insert(result.Count, reminder);
            }

            result.Reverse();

            Console.WriteLine(string.Join("", result).TrimStart('0'));
        }
    }
}
