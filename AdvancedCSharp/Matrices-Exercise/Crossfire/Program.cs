using System;
using System.Linq;

namespace Crossfire
{
    public class Program
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new int[rows][];
            var count = 1;

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = count++;
                }
            }

            var input = Console.ReadLine();

            while(input != "Nuke it from orbit")
            {
                var args = input
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var row = args[0];
                var col = args[1];
                var radius = args[2];

                for (int i = row - radius; i <= row + radius; i++)
                {
                    if(IsInMatrix(matrix, i, col))
                    {
                        matrix[i][col] = -1;
                    }
                }

                for (int i = col - radius; i <= col + radius; i++)
                {
                    if (IsInMatrix(matrix, row, i))
                    {
                        matrix[row][i] = -1;
                    }
                }

                matrix = filterMatrix(matrix);

                input = Console.ReadLine();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", string.Join(" ", matrix[i])));
            }
        }

        private static bool IsInMatrix(int[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int[][] filterMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(matrix[i][j] < 0)
                    {
                        matrix[i] = matrix[i]
                        .Where(k => k > -1)
                        .ToArray();
                    }
                }

                if (matrix[i].Length < 1)
                {
                    matrix = matrix
                        .Take(i)
                        .Concat(matrix.Skip(i + 1))
                        .ToArray();

                    i--;
                }
            }

            return matrix;
        }
    }
}
