using System;
using System.Linq;

namespace SquaresInMatrix
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[input[0]][];

            for (int i = 0; i < input[0]; i++)
            {
                var row = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[i] = row;
            }

            var count = 0;

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    if (matrix[i][j] == matrix[i][j + 1]
                        && matrix[i][j] == matrix[i + 1][j]
                        && matrix[i][j] == matrix[i + 1][j + 1])
                        count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
