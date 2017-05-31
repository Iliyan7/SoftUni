using System;
using System.Linq;

namespace SquareWithMaximumSum
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

            var maxSum = int.MinValue;
            var biggestSquareMatrix = new int[2][];
            
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    var currentSum = matrix[i][j] + matrix[i][j + 1] + matrix[i + 1][j] + matrix[i + 1][j + 1];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;

                        biggestSquareMatrix[0] = new int[] { matrix[i][j], matrix[i][j + 1] };
                        biggestSquareMatrix[1] = new int[] { matrix[i + 1][j], matrix[i + 1][j + 1] };
                    }
                }
            }

            Console.WriteLine(string.Join(" ", biggestSquareMatrix[0]));
            Console.WriteLine(string.Join(" ", biggestSquareMatrix[1]));
            Console.WriteLine(maxSum);

        }
    }
}
