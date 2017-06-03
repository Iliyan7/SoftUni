using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[input[0]][];

            for (int i = 0; i < input[0]; i++)
            {
                var row = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = row;
            }

            var maxSum = int.MinValue;
            var maxSumMatrix = new int[3][];

            for (int i = 0; i < matrix.Length - 2; i++)
            {
                for (int j = 0; j < matrix[i].Length - 2; j++)
                {
                    var currentSum = matrix[i].Skip(j).Take(3).Sum()
                        + matrix[i + 1].Skip(j).Take(3).Sum()
                        + matrix[i + 2].Skip(j).Take(3).Sum();

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;

                        maxSumMatrix[0] = new int[] { matrix[i][j], matrix[i][j + 1], matrix[i][j + 2] };
                        maxSumMatrix[1] = new int[] { matrix[i + 1][j], matrix[i + 1][j + 1], matrix[i + 1][j + 2] };
                        maxSumMatrix[2] = new int[] { matrix[i + 2][j], matrix[i + 2][j + 1], matrix[i + 2][j + 2] };
                    }
                }
            }

            Console.WriteLine("Sum = {0}", maxSum);
            Console.WriteLine(string.Join(" ", maxSumMatrix[0]));
            Console.WriteLine(string.Join(" ", maxSumMatrix[1]));
            Console.WriteLine(string.Join(" ", maxSumMatrix[2]));
        }
    }
}
