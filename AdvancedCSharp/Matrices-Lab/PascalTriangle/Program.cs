using System;

namespace PascalTriangle
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var jaggedArray = new long[n][];
            jaggedArray[0] = new long[] { 1 };

            for (int i = 1; i < n; i++)
            {
                jaggedArray[i] = new long[i+1];
                jaggedArray[i][0] = 1;
                jaggedArray[i][jaggedArray[i].Length - 1] = 1;

                for (int j = 1; j < jaggedArray[i].Length - 1; j++)
                {
                    jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }
    }
}
