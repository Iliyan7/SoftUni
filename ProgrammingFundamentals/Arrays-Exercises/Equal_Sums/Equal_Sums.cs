using System;
using System.Linq;

namespace Equal_Sums
{
    public class Equal_Sums
    {
        public static void Main()
        {
            int[] seq = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool indexFound = false;

            for (int i = 0; i < seq.Length; i++)
            {
                if (LeftSumOfElements(seq, 0, i - 1) == RightSumOfElements(seq, i + 1, seq.Length - 1))
                {
                    Console.WriteLine(i);
                    indexFound = true;
                }
            }

            if(!indexFound) Console.WriteLine("no");
        }

        public static int LeftSumOfElements(int[] arr, int startindex, int endindex)
        {
            return SumOfElemtns(arr, startindex, endindex);
        }

        public static int RightSumOfElements(int[] arr, int startindex, int endindex)
        {
            return SumOfElemtns(arr, startindex, endindex);
        }

        public static int SumOfElemtns(int[] arr, int startindex, int endindex)
        {
            int sum = 0;

            for (int i = startindex; i <= endindex; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
    }
}
