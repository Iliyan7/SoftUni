using System;
using System.Linq;

namespace RadioactiveBunnies
{
    public class Program
    {
        private enum Stage
        {
            Alive,
            Won,
            Dead
        };

        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rows = input[0];

            var lair = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                var arr = Console.ReadLine()
                    .ToCharArray();

                lair[i] = arr;
            }

            var directions = Console.ReadLine();

            var playerStage = Stage.Alive;
            var playerRow = 0;
            var playerCol = 0;

            foreach (var direction in directions)
            {
                playerCol = GetPlayerIndex(lair, out playerRow);

                switch (direction)
                {
                    case 'L': playerStage = MovePlayerLeftRight(lair, playerRow, ref playerCol, -1); break;
                    case 'R': playerStage = MovePlayerLeftRight(lair, playerRow, ref playerCol, 1); break;
                    case 'U': playerStage = MovePlayerUpDown(lair, ref playerRow, playerCol, -1); break;
                    case 'D': playerStage = MovePlayerUpDown(lair, ref playerRow, playerCol, 1); break;
                }

                if (playerStage == Stage.Won || playerStage == Stage.Dead)
                    break;
            }

            for (int i = 0; i < lair.Length; i++)
            {
                Console.WriteLine(string.Join("", lair[i]));
            }

            if (playerStage == Stage.Won)
            {
                Console.WriteLine("won: {0} {1}", playerRow, playerCol);
            }
            else if (playerStage == Stage.Dead)
            {
                Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
            }
        }

        private static int GetPlayerIndex(char[][] lair, out int row)
        {
            row = 0;
            var pIndex = 0;

            for (int i = 0; i < lair.Length; i++)
            {
                pIndex = Array.IndexOf(lair[i], 'P');

                if (pIndex > -1)
                {
                    row = i;
                    break;
                }
            }

            return pIndex;
        }

        private static Stage MovePlayerLeftRight(char[][] lair, int playerRow, ref int playerCol, int step)
        {
            var playerStage = Stage.Alive;

            try
            {
                lair[playerRow][playerCol] = '.';

                if (lair[playerRow][playerCol + step] == '.')
                {
                    lair[playerRow][playerCol + step] = 'P';
                }
                else
                {
                    playerCol += step;

                    playerStage = Stage.Dead;
                }

                if (BunniesSpread(lair))
                {
                    playerCol += step;

                    playerStage = Stage.Dead;
                }
            }
            catch (IndexOutOfRangeException)
            {
                playerStage = Stage.Won;
                BunniesSpread(lair);
            }

            return playerStage;
        }

        private static Stage MovePlayerUpDown(char[][] lair, ref int playerRow, int playerCol, int step)
        {
            var playerStage = Stage.Alive;

            try
            {
                lair[playerRow][playerCol] = '.';

                if (lair[playerRow + step][playerCol] == '.')
                {
                    lair[playerRow + step][playerCol] = 'P';
                }
                else
                {
                    playerRow += step;

                    playerStage = Stage.Dead;
                }

                if (BunniesSpread(lair))
                {
                    playerRow += step;
                    playerStage = Stage.Dead;
                }
            }
            catch (IndexOutOfRangeException)
            {
                playerStage = Stage.Won;

                BunniesSpread(lair);
            }

            return playerStage;
        }

        private static bool BunniesSpread(char[][] lair)
        {
            var tempLair = new char[lair.Length][];

            for (int i = 0; i < lair.Length; i++)
            {
                tempLair[i] = new char[lair[i].Length];

                for (int j = 0; j < lair[i].Length; j++)
                {
                    tempLair[i][j] = lair[i][j];
                }
            }

            var playerDead = false;

            for (int i = 0; i < lair.Length; i++)
            {
                for (int j = 0; j < lair[i].Length; j++)
                {
                    if (tempLair[i][j] != 'B')
                        continue;

                    try
                    {
                        if (lair[i - 1][j] == 'P')
                            playerDead = true;

                        lair[i - 1][j] = 'B';
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (lair[i + 1][j] == 'P')
                            playerDead = true;

                        lair[i + 1][j] = 'B';
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (lair[i][j - 1] == 'P')
                            playerDead = true;

                        lair[i][j - 1] = 'B';
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (lair[i][j + 1] == 'P')
                            playerDead = true;

                        lair[i][j + 1] = 'B';
                    }
                    catch (IndexOutOfRangeException) { }
                }
            }

            return playerDead;
        }
    }
}
