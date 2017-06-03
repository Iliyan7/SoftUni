using System;
using System.Linq;

namespace DiagonalDifference
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = row;
            }

            var primarySum = SumPrimaryDiagonal(matrix);
            var secondarySum = SumSecondaryDiagonal(matrix);

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }

        private static int SumPrimaryDiagonal(int[][] matrix)
        {
            var sum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][i];
            }

            return sum;
        }

        private static int SumSecondaryDiagonal(int[][] matrix)
        {
            var sum = 0;

            for (int i = 0, j = matrix[i].Length - 1; i < matrix.Length; i++, j--)
            {
                sum += matrix[i][j];
            }

            return sum;
        }
    }
}
