using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var board = new char[size][];
            PrepareBoard(board);

            var knightHits = new List<Tuple<int, int, int>>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if(board[i][j] == 'K')
                    {
                        knightHits.Add(new Tuple<int, int, int> (GetKnightHits(board, i, j), i, j));
                    }
                }
            }

            knightHits = knightHits
                .OrderByDescending(x => x.Item1)
                .ToList();

            var minRemoves = 0;

            foreach (var kn in knightHits)
            {
                if (RemoveAndCheckWhetherHit(board, kn.Item2, kn.Item3))
                    minRemoves++;

            }

            Console.WriteLine(minRemoves);
        }

        private static bool RemoveAndCheckWhetherHit(char[][] board, int x, int y)
        {
            board[x][y] = '0';

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'K')
                    {
                        if (GetKnightHits(board, x, y) > 0)
                            return true;
                    }
                }
            }

            return false;
        }

        private static int GetKnightHits(char[][] board, int i, int j)
        {
            var count = 0;

            foreach (var pos in GetAllValidMoves(i, j, board))
            {
                if (board[pos[0]][pos[1]] == 'K')
                    count++;
            }

            return count;
        }

        private static List<int[]> GetAllValidMoves(int x, int y, char[][] board)
        {
            var deltas = new int[8][]
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

            var xCandidate = 0;
            var yCandidate = 0;

            var validPos = new List<int[]>();

            for (int i = 0; i < 8; i++)
            {
                xCandidate = x + deltas[i][0];
                yCandidate = y + deltas[i][1];

                if(0 < xCandidate && xCandidate < board.Length && 0 < yCandidate && yCandidate < board[0].Length)
                {
                    validPos.Add(new int[] { xCandidate, yCandidate });
                }
            }

            return validPos;
        }

        private static void PrepareBoard(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = Console.ReadLine()
                    .ToCharArray();
            }
        }
    }
}
