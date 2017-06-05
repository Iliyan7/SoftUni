using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    public class Program
    {
        private static IDictionary<int, HashSet<int>> spotsTaken;

        public static void Main()
        {
            spotsTaken = new Dictionary<int, HashSet<int>>();

            var dimensions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var command = String.Empty;

            while ((command = Console.ReadLine()) != "stop")
            {
                var args = command
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = args[0];
                var targetRow = args[1];
                var targetCol = args[2];

                if (IsSpotTaken(targetRow, targetCol))
                {
                    targetCol = TryFindFreeSpot(targetRow, targetCol, cols);
                }

                if (targetCol > 0)
                {
                    MarkSpotAsTaken(targetRow, targetCol);

                    var distance = Math.Abs(targetRow - entryRow) + targetCol + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    Console.WriteLine("Row {0} full", targetRow);
                }
            }
        }

        private static int TryFindFreeSpot(int targetRow, int targetCol, int cols)
        {
            int newCol = 0;
            int bestLength = int.MaxValue;

            for (int i = 1; i < cols; i++)
            {
                if (!IsSpotTaken(targetRow, i))
                {
                    int newLength = Math.Abs(targetCol - i);
                    if (newLength < bestLength)
                    {
                        bestLength = newLength;
                        newCol = i;
                    }
                }
            }

            return newCol;
        }

        private static bool IsSpotTaken(int targetRow, int targetCol)
            {
                return spotsTaken.ContainsKey(targetRow) && spotsTaken[targetRow].Contains(targetCol);
            }

        private static void MarkSpotAsTaken(int targetRow, int targetCol)
        {
            if (!spotsTaken.ContainsKey(targetRow))
            {
                spotsTaken[targetRow] = new HashSet<int>();
            }

            spotsTaken[targetRow].Add(targetCol);
        }
    }
}
