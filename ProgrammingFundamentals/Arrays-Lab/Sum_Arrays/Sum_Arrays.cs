using System;
using System.Linq;

namespace Sum_Arrays
{
    public class Sum_Arrays
    {
        public static void Main()
        {
            int[] firstArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int firstLen = firstArr.Length;
            int secondLen = secondArr.Length;
            int biggerArrLen = Math.Max(firstLen, secondLen);

            int[] sumResult = new int[biggerArrLen];

            if (firstLen == secondLen)
            {
                sumResult = SumArrays(firstArr, secondArr);
            }
            else
            {
                int[] duplicatedArr = new int[biggerArrLen];

                if (firstLen < secondLen)
                {
                    duplicatedArr = DuplicateSmallerArray(firstArr, secondLen);
                    sumResult = SumArrays(secondArr, duplicatedArr);
                }
                else if (firstLen > secondLen)
                {
                    duplicatedArr = DuplicateSmallerArray(secondArr, firstLen);
                    sumResult = SumArrays(firstArr, duplicatedArr);
                }
            }

            Console.WriteLine(string.Join(" ", sumResult));
        }

        public static int[] DuplicateSmallerArray(int[] arrToDuplicate, int len)
        {
            int[] duplicatedArr = new int[len];

            int counter = 0, i = 0, j = 0;

            while (j < duplicatedArr.Length)
            {
                if (i == arrToDuplicate.Length)
                {
                    i = 0;
                    counter += arrToDuplicate.Length;
                }

                duplicatedArr[i + counter] = arrToDuplicate[i];

                i++; j++;
            }

            return duplicatedArr;
        }

        public static int[] SumArrays(int[] arrA, int[] arrB)
        {
            int[] arrC = new int[arrA.Length];

            for (int i = 0; i < arrA.Length; i++)
            {
                arrC[i] = arrA[i] + arrB[i];
            }

            return arrC;
        }
    }
}
