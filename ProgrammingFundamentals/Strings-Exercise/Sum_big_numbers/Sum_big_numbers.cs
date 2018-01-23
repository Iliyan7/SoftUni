using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_big_numbers
{
    public class Sum_big_numbers
    {
        public static void Main()
        {
            var numOne = Console.ReadLine().Select(x => int.Parse(char.ToString(x))).ToList();
            var numTwo = Console.ReadLine().Select(x => int.Parse(char.ToString(x))).ToList();

            var zerosToInstert = Math.Abs(numOne.Count - numTwo.Count);

            var firstNum = numOne.Count > numTwo.Count ? numTwo : numOne;
            var secondNum = firstNum == numOne ? numTwo : numOne;

            while (zerosToInstert-- > 0)
            {
                firstNum.Insert(0, 0);
            }

            var result = new List<int>();
            var rest = 0;

            for (int i = firstNum.Count - 1; i >= 0; i--)
            {
                int sum = firstNum[i] + secondNum[i] + rest;

                if (sum < 10)
                {
                    result.Add(sum);
                    rest = 0;
                }
                else
                {
                    result.Add(sum % 10);
                    rest = 1;
                }
            }

            if (rest == 1) result.Insert(result.Count, 1);

            result.Reverse();
            Console.WriteLine(string.Join("", result).TrimStart('0'));
        }
    }
}
