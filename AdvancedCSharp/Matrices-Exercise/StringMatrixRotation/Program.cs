using System;
using System.Collections.Generic;

namespace StringMatrixRotation
{
    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine()
                .Replace("Rotate(", String.Empty)
                .Replace(")", string.Empty);

            var degrees = int.Parse(command) % 360;

            var matrix = CreateMatrix();

            switch (degrees)
            {
                case 0:
                    {
                        for (int i = 0; i < matrix.Length; i++)
                            Console.WriteLine(string.Join("", matrix[i]));

                        break;
                    }
                case 90:
                    {
                        var result = Rotate90degrees(matrix);

                        PrintResultMatrix(result);

                        break;
                    }
                case 180:
                    {
                        var result = Rotate180degrees(matrix);

                        PrintResultMatrix(result);

                        break;
                    }
                case 270:
                    {
                        var result = Rotate270degrees(matrix);

                        PrintResultMatrix(result);

                        break;
                    }
            }

        }

        private static char[,] Rotate90degrees(char[][] matrix)
        {
            var rowSize = matrix.Length;
            var colSize = matrix[0].Length;

            var result = new char[colSize, rowSize];

            for (int rRow = 0, oCol = 0; rRow < colSize; rRow++, oCol++)
            {
                for (int rCol = 0, oRow = rowSize - 1; rCol < rowSize; rCol++, oRow--)
                {
                    result[rRow, rCol] = matrix[oRow][oCol];
                }
            }

            return result;
        }

        private static char[,] Rotate180degrees(char[][] matrix)
        {
            var rowSize = matrix.Length;
            var colSize = matrix[0].Length;

            var result = new char[rowSize, colSize];

            for (int rRow = 0, oRow = rowSize - 1; rRow < rowSize; rRow++, oRow--)
            {
                for (int rCol = 0, oCol = colSize - 1; rCol < colSize; rCol++, oCol--)
                {
                    result[rRow, rCol] = matrix[oRow][oCol];
                }
            }

            return result;
        }

        private static char[,] Rotate270degrees(char[][] matrix)
        {
            var rowSize = matrix.Length;
            var colSize = matrix[0].Length;

            var result = new char[colSize, rowSize];

            for (int rRow = 0, oCol = colSize - 1; rRow < colSize; rRow++, oCol--)
            {
                for (int rCol = 0, oRow = 0; rCol < rowSize; rCol++, oRow++)
                {
                    result[rRow, rCol] = matrix[oRow][oCol];
                }
            }

            return result;
        }

        private static char[][] CreateMatrix()
        {
            var line = String.Empty;
            var list = new List<char[]>();

            while ((line = Console.ReadLine()) != "END")
            {
                list.Add(line.ToCharArray());
            }

            var maxRow = list.Count;
            var maxCol = GetMaxCol(list);

            var matrix = new char[maxRow][];
            for (int i = 0; i < maxRow; i++)
            {
                matrix[i] = new char[maxCol];

                for (int j = 0; j < maxCol; j++)
                {
                    try
                    {
                        matrix[i][j] = list[i][j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }

            return matrix;
        }

        private static int GetMaxCol(List<char[]> list)
        {
            var maxLen = -1;

            foreach (var arr in list)
            {
                if (arr.Length > maxLen)
                {
                    maxLen = arr.Length;
                }
            }

            return maxLen;
        }

        private static void PrintResultMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}