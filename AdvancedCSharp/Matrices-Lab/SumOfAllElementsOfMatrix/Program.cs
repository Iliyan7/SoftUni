using System;
using System.Linq;

namespace SumOfAllElementsOfMatrix
{
    public class Program
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine();

            var len = int.Parse(matrixSizes[0].ToString());
            var matrix = new int[len][];

            for (int i = 0; i < len; i++)
            {
                var arr = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = arr;
            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(matrix.Sum(x => x.Sum()));
        }
    }
}
