using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    public class Program
    {
        public static readonly int[][] deltas = new int[8][]
        {
            new int[] {-2, -1},
            new int[] {-2, +1},
            new int[] {+2, -1},
            new int[] {+2, +1},
            new int[] {-1, -2},
            new int[] {-1, +2},
            new int[] {+1, -2},
            new int[] {+1, +2}
        };

        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var board = new char[size][];
            PrepareBoard(board);

            var knights = new List<Knight>();

            for (int x = 0; x < board.Length; x++)
            {
                for (int y = 0; y < board[x].Length; y++)
                {
                    if (board[x][y] == 'K')
                    {
                        knights.Add(new Knight()
                        {
                            X = x,
                            Y = y,
                            Targets = GetKnightAttacks(x, y, board)
                        });
                    }
                }
            }

            var count = 0;
            while (knights.Any(k => k.Targets.Count > 0))
            {
                var knight = knights.OrderByDescending(k => k.Targets.Count).First();

                board[knight.X][knight.Y] = '0';
                count++;

                foreach (var targetKnightTuple in knight.Targets)
                {
                    var targetKnight = knights.Single(k => k.X == targetKnightTuple.Item1 && k.Y == targetKnightTuple.Item2);

                    targetKnight.Targets.Remove(new Tuple<int, int>(knight.X, knight.Y));
                }

                knight.Targets.Clear();
            }

            Console.WriteLine(count);
        }

        private static void PrepareBoard(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = Console.ReadLine()
                    .ToCharArray();
            }
        }

        private static List<Tuple<int, int>> GetKnightAttacks(int x, int y, char[][] board)
        {
            var xCandidate = 0;
            var yCandidate = 0;

            var list = new List<Tuple<int, int>>();

            for (int i = 0; i < 8; i++)
            {
                xCandidate = x + deltas[i][0];
                yCandidate = y + deltas[i][1];

                if (0 <= xCandidate && xCandidate < board.Length
                    && 0 <= yCandidate && yCandidate < board[0].Length
                    && board[xCandidate][yCandidate] == 'K')
                {
                    list.Add(new Tuple<int, int>(xCandidate, yCandidate));
                }
            }

            return list;
        }

        private class Knight
        {
            public int X { get; set; }

            public int Y { get; set; }

            public List<Tuple<int, int>> Targets { get; set; } = new List<Tuple<int, int>>();
        }
    }
}
