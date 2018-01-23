using System;
using System.Linq;

namespace Largest_Common_End
{
    public class Largest_Common_End
    {
        public static void Main()
        {
            string[] firstLineOfWords = Console.ReadLine().Split(' ').ToArray();
            string[] secondLineOfWords = Console.ReadLine().Split(' ').ToArray();

            int leftCommonEnd = ScanFromLeftToRight(firstLineOfWords, secondLineOfWords);
            int rightCommonEnd = ScanFromRightToLeft(firstLineOfWords, secondLineOfWords);

            Console.WriteLine("{0}", Math.Max(leftCommonEnd, rightCommonEnd));
        }

        public static int ScanFromLeftToRight(string[] arr1, string[] arr2)
        {
            int min = Math.Min(arr1.Length, arr2.Length);

            int count = 0;

            for (int i = 0; i < min; i++)
            {
                if (arr1[i] != arr2[i])
                    break;

                count++;
            }

            return count;
        }

        public static int ScanFromRightToLeft(string[] arr1, string[] arr2)
        {
            ReverseArray(arr1);
            ReverseArray(arr2);

            return ScanFromLeftToRight(arr1, arr2);
        }

        public static void ReverseArray(string[] array)
        {
            string[] tempArr = new string[array.Length];
            Array.Copy(array, tempArr, array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = tempArr[tempArr.Length - 1 - i];
            }
        }
    }
}
