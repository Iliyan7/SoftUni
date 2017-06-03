using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rowSize = input[0];
            var colSize = input[1];

            var matrix = new string[rowSize][];

            for (int i = 0; i < rowSize; i++)
            {
                matrix[i] = new string[colSize];

                for (int j = 0; j < colSize; j++)
                {
                    matrix[i][j] = GetWord(i, j);
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static string GetWord(int row, int col)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz"
                .ToCharArray();

            return string.Format("{0}{1}{2}", alphabet[row], alphabet[row + col], alphabet[row]);
        }
    }
}
