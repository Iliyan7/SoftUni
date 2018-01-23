using System;
using System.Linq;

namespace Fold_and_Sum
{
    public class Fold_and_Sum
    {
        public static void Main()
        {
            int[] numArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] firstRow = GetFirstRow(numArr, numArr.Length);
            int[] secondRow = GetSecondRow(numArr, numArr.Length);

            Console.WriteLine(string.Join(" ", SumArrayRows(firstRow, secondRow)));
        }

        public static int[] GetFirstRow(int[] numArr, int len)
        {
            int[] tempArr = new int[len / 2];

            int foldedSize = tempArr.Length / 2;

            for (int i = 0; i < foldedSize; i++)
            {
                tempArr[i] = numArr[foldedSize - 1 - i];
            }

            for (int i = foldedSize; i < tempArr.Length; i++)
            {
                tempArr[i] = numArr[len - 1 - (i - foldedSize)];
            }

            return tempArr;
        }

        public static int[] GetSecondRow(int[] numArr, int len)
        {
            int[] tempArr = new int[len / 2];

            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = numArr[i + (len / 4)];
            }

            return tempArr;
        }

        public static int[] SumArrayRows(int[] arr1, int[] arr2)
        {
            int[] totalSum = new int[arr1.Length];

            for (int i = 0; i < totalSum.Length; i++)
            {
                totalSum[i] = arr1[i] + arr2[i];
            }

            return totalSum;
        }
    }
}
