using System;
using System.Linq;

namespace TargetPractice
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

            var snake = Console.ReadLine();

            var shotParams = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[rows][];

            var count = 0;
            var swapSide = true;

            for (int i = rows - 1; i >= 0; i--)
            {
                matrix[i] = new char[cols];

                if (swapSide)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        matrix[i][j] = snake[count++ % snake.Length];
                    }
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i][j] = snake[count++ % snake.Length];
                    }
                }

                swapSide = !swapSide;
            }

            ShotMatrix(matrix, shotParams[0], shotParams[1], shotParams[2]);

            DropCharacters(matrix);

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static void ShotMatrix(char[][] matrix, int row, int col, int radius)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (IsInRadius(i, row, j, col, radius))
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }
        }

        private static bool IsInRadius(int x1, int x2, int y1, int y2, int radius)
        {
            var x = x1 - x2;
            var y = y1 - y2;

            return x * x + y * y <= radius * radius;
        }

        private static void DropCharacters(char[][] matrix)
        {
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != ' ')
                        continue;

                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (matrix[k][j] != ' ')
                        {
                            matrix[i][j] = matrix[k][j];
                            matrix[k][j] = ' ';
                            break;
                        }
                    }
                }
            }
        }
    }
}
