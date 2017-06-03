using System;
using System.Linq;

namespace RubiksMatrix
{
    public class Program
    {
        public static void Main()
        {
            var rc = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var row = rc[0];
            var col = rc[1];

            var matrix = new int[row][];

            var count = 1;
            for (int i = 0; i < row; i++)
            {
                matrix[i] = new int[col];

                for (int j = 0; j < col; j++)
                {
                    matrix[i][j] = count++;
                }
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var rcIndex = int.Parse(args[0]);
                var direction = args[1];
                var moves = int.Parse(args[2]);

                switch(direction)
                {
                    case "up": MoveCol(matrix, rcIndex, moves); break;
                    case "down": MoveCol(matrix, rcIndex, row - moves % row); break;
                    case "left": MoveRow(matrix, rcIndex, moves); break;
                    case "right": MoveRow(matrix, rcIndex, col - moves % col); break;
                }
            }

            count = 1;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i][j] == count)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var oRow = 0;
                        var oCol = 0;
                        GetRearrangedRowAndCol(matrix, count, out oRow, out oCol);

                        matrix[oRow][oCol] = matrix[i][j];
                        matrix[i][j] = count;

                        Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})", i, j, oRow, oCol);
                    }

                    count++;
                }
            }
        }

        private static void MoveCol(int[][] rearrangedMatrix, int rcIndex, int moves)
        {
            var len = rearrangedMatrix.Length;
            var tempArr = new int[len];

            for (int i = 0; i < len; i++)
            {
                tempArr[i] = rearrangedMatrix[(i + moves) % len][rcIndex];
            }

            for (int i = 0; i < len; i++)
            {
                rearrangedMatrix[i][rcIndex] = tempArr[i];
            }
        }
        private static void MoveRow(int[][] rearrangedMatrix, int rcIndex, int moves)
        {
            var len = rearrangedMatrix[0].Length;
            var tempArr = new int[len];

            for (int i = 0; i < len; i++)
            {
                tempArr[i] = rearrangedMatrix[rcIndex][(i + moves) % len];
            }

            for (int i = 0; i < len; i++)
            {
                rearrangedMatrix[rcIndex][i] = tempArr[i];
            }
        }

        private static void GetRearrangedRowAndCol(int[][] matrix, int searchFor, out int oRow, out int oCol)
        {
            oRow = 0;
            oCol = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == searchFor)
                    {
                        oRow = i;
                        oCol = j;

                        return;
                    }
                }
            }
        }
    }
}
