using System;
using System.Linq;

namespace Tripple_Sum
{
    public class Tripple_Sum
    {
        public static void Main()
        {
            //long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            string[] strNumbers = Console.ReadLine().Split(' ');
            long[] numbers = strNumbers.Select(long.Parse).ToArray();

            bool isNo = true;

            for (int a = 0; a < numbers.Length; a++)
            {
                for (int b = a + 1; b < numbers.Length; b++)
                {
                    long sum = numbers[a] + numbers[b];
                    if (numbers.Contains(sum))
                    {
                        Console.WriteLine("{0} + {1} == {2}", numbers[a], numbers[b], sum);
                        isNo = false;
                    }
                }
            }

            if (isNo) Console.WriteLine("No");
        }
    }
}
