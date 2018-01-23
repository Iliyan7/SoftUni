using System;
using System.Linq;

namespace Reverse_Array_of_Strings
{
    public class Reverse_Array_of_Strings
    {
        public static void Main()
        {
            string[] arrStrings = Console.ReadLine().Split(' ').ToArray();

            string[] reversedArr = new string[arrStrings.Length];

            for (int i = 0; i < arrStrings.Length; i++)
            {
                reversedArr[i] = arrStrings[arrStrings.Length - 1 - i];
            }

            Console.WriteLine(string.Join(" ", reversedArr));
        }
    }
}
