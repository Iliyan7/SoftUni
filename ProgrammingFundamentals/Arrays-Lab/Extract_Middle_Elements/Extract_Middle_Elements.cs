using System;
using System.Linq;

namespace Extract_Middle_Elements
{
    public class Extract_Middle_Elements
    {
        public static void Main()
        {
            int[] intArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = intArr.Length;

            if (n == 1)
            {
                Console.WriteLine(intArr[0]);
            }
            else if (n % 2 == 0)
            {
                Console.WriteLine("{0}, {1}", intArr[n/2-1], intArr[n/2]);
            }
            else
            {
                Console.WriteLine("{0}, {1}, {2}", intArr[n/2-1], intArr[n/2], intArr[n/2+1]);
            }
        }
    }
}
