using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Reversed_Numbers
{
    public class Sum_Reversed_Numbers
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> revNums = new List<int>();

            for (int i = 0; i < numbers.Count(); i++)
            {
                revNums.Add(ReverseNumber(numbers[i]));
            }

            Console.WriteLine(revNums.Sum());
        }

        public static int ReverseNumber(int num)
        {
            return int.Parse(new string(num.ToString().Reverse().ToArray()));
        }
    }
}
