using System;

namespace Reverse_Array_of_Integers
{
    public class Reverse_Array_of_Integers
    {
        public static void Main()
        {
            int len = int.Parse(Console.ReadLine());

            int[] arrInts = new int[len];

            for (int i = 0; i < arrInts.Length; i++)
            {
                arrInts[i] = int.Parse(Console.ReadLine());
            }

            int[] reversedArr = new int[arrInts.Length];

            for (int i = 0; i < reversedArr.Length; i++)
            {
                reversedArr[i] = arrInts[reversedArr.Length - i - 1];
            }

            Console.WriteLine(string.Join(" ", reversedArr));
        }
    }
}
