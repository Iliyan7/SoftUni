using System;
using System.Linq;

namespace LegoBlocks
{
    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var firstJaggedArray = new int[rows][];
            var secondJaggedArray = new int[rows][];

            for (int i = 0; i < rows * 2; i++)
            {
                var arr = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (i < rows)
                    firstJaggedArray[i] = arr;
                else
                    secondJaggedArray[i % rows] = arr;
            }

            var mergedArray = MergeArrays(firstJaggedArray, secondJaggedArray);

            bool isRectangular = IsArrayRectangular(mergedArray);

            if (isRectangular)
            {
                for (int i = 0; i < mergedArray.Length; i++)
                {
                    Console.WriteLine("[{0}]", string.Join(", ", mergedArray[i]));
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}", GetCellsCount(mergedArray));
            }
        }

        private static int[][] MergeArrays(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            var mergedArray = new int[firstJaggedArray.Length][];

            for (int i = 0; i < firstJaggedArray.Length; i++)
            {
                Array.Reverse(secondJaggedArray[i]);
                mergedArray[i] = new int[firstJaggedArray[i].Length + secondJaggedArray[i].Length];

                for (int j = 0; j < mergedArray[i].Length; j++)
                {
                    if (j < firstJaggedArray[i].Length)
                        mergedArray[i][j] = firstJaggedArray[i][j];
                    else
                        mergedArray[i][j] = secondJaggedArray[i][j % firstJaggedArray[i].Length];
                }
            }

            return mergedArray;
        }

        private static bool IsArrayRectangular(int[][] mergedArray)
        {
            var count = mergedArray[0].Count();

            for (int i = 1; i < mergedArray.Length; i++)
            {
                if (count != mergedArray[i].Count())
                    return false;
            }

            return true;
        }

        private static int GetCellsCount(int[][] mergedArray)
        {
            var cells = 0;

            for (int i = 0; i < mergedArray.Length; i++)
            {
                cells += mergedArray[i].Count();
            }

            return cells;
        }
    }
}
