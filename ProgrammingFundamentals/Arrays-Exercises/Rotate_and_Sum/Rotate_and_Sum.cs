using System;
using System.Linq;

namespace Rotate_and_Sum
{
    public class Rotate_and_Sum
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            int[] totalSum = new int[numbers.Length];

            for (int i = 0; i < k; i++)
            {
                RotateNumbers(numbers);

                for (int j = 0; j < numbers.Length; j++)
                {
                    totalSum[j] += numbers[j];
                }
            }

            Console.WriteLine(string.Join(" ", totalSum));
        }

        public static void RotateNumbers(int[] arr)
        {
            int lastNum = arr[arr.Length - 1];

            int[] tempArr = new int[arr.Length];
            Array.Copy(arr, tempArr, arr.Length);

            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = tempArr[i - 1];
            }

            arr[0] = lastNum;
        }
    }
}
