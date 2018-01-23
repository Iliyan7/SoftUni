using System;
using System.Collections.Generic;
using System.Linq;

namespace Multiply_big_number
{
    public class Multiply_big_number
    {
        public static void Main()
        {
            var bigNumber = Console.ReadLine().Select(x => int.Parse(char.ToString(x))).ToList();
            var digit = int.Parse(Console.ReadLine());

            if(digit == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var result = new List<int>();
            var rest = 0;

            for (int i = bigNumber.Count - 1; i >= 0; i--)
            {
                var sum = bigNumber[i] * digit + rest;

                if (sum < 10)
                {
                    result.Add(sum);
                    rest = 0;
                }
                else
                {
                    result.Add(sum % 10);
                    rest = sum / 10;
                }
            }

            if (rest != 0) result.Insert(result.Count, rest);

            result.Reverse();
            Console.WriteLine(string.Join("", result).TrimStart('0'));
        }
    }
}
