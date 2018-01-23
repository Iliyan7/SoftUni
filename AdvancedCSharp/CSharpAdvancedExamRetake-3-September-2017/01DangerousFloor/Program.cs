using System;
using System.Linq;

namespace _01DangerousFloor
{
    class Program
    {
        private const string SuccessfulMoveMessage = "checked";
        private const string InvalidMoveMessage = "Invalid move!";
        private const string OutOfBoardMessage = "Move go out of board!";
        public static void Main()
        {
            var board = new char[8][];

            for (int i = 0; i < board.Length; i++)
            {
                var row = Console.ReadLine()
                    .Split(',')
                    .Select(char.Parse)
                    .ToArray();

                board[i] = row;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var piece = command[0];
                var startPosX = int.Parse(command[1].ToString());
                var startPosY = int.Parse(command[2].ToString());
                var endPosX = int.Parse(command[4].ToString());
                var endPosY = int.Parse(command[5].ToString());

                if (!IsValidPiece(board, piece, startPosX, startPosY))
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                var msg = MovePiece(board, piece, startPosX, startPosY, endPosX, endPosY);

                if (!msg.Equals(SuccessfulMoveMessage))
                    Console.WriteLine(msg);
            }
        }

        private static bool IsValidPiece(char[][] board, char piece, int startPosX, int startPosY)
        {
            if (board[startPosX][startPosY] == piece)
                return true;

            return false;
        }

        private static string MovePiece(char[][] board, char piece, int startPosX, int startPosY, int endPosX, int endPosY)
        {
            var messageResult = InvalidMoveMessage;

            switch (piece)
            {
                case 'K':
                    if (IsValidKingMove(startPosX, startPosY, endPosX, endPosY))
                    {
                        if (IsMoveWithinBoard(endPosX, endPosY))
                        {
                            board[startPosX][startPosY] = 'x';
                            board[endPosX][endPosY] = 'K';

                            messageResult = SuccessfulMoveMessage;
                        }
                        else
                        {
                            messageResult = OutOfBoardMessage;
                        }
                    }
                    break;

                case 'R':
                    if (IsValidRookMove(startPosX, startPosY, endPosX, endPosY))
                    {
                        if (IsMoveWithinBoard(endPosX, endPosY))
                        {
                            board[startPosX][startPosY] = 'x';
                            board[endPosX][endPosY] = 'R';

                            messageResult = SuccessfulMoveMessage;
                        }
                        else
                        {
                            messageResult = OutOfBoardMessage;
                        }
                    }
                    break;

                case 'B':
                    if (IsValidBishopMove(startPosX, startPosY, endPosX, endPosY))
                    {
                        if (IsMoveWithinBoard(endPosX, endPosY))
                        {
                            board[startPosX][startPosY] = 'x';
                            board[endPosX][endPosY] = 'B';

                            messageResult = SuccessfulMoveMessage;
                        }
                        else
                        {
                            messageResult = OutOfBoardMessage;
                        }
                    }
                    break;
                case 'Q':
                    if (IsValidRookMove(startPosX, startPosY, endPosX, endPosY) || IsValidBishopMove(startPosX, startPosY, endPosX, endPosY))
                    {
                        if (IsMoveWithinBoard(endPosX, endPosY))
                        {
                            board[startPosX][startPosY] = 'x';
                            board[endPosX][endPosY] = 'Q';

                            messageResult = SuccessfulMoveMessage;
                        }
                        else
                        {
                            messageResult = OutOfBoardMessage;
                        }
                    }
                    break;

                case 'P':
                    if (startPosX - 1 == endPosX && startPosY == endPosY)
                    {
                        if (IsMoveWithinBoard(endPosX, endPosY))
                        {
                            board[startPosX][startPosY] = 'x';
                            board[endPosX][endPosY] = 'P';
                            
                            messageResult = SuccessfulMoveMessage;
                        }
                        else
                        {
                            messageResult = OutOfBoardMessage;
                        }
                    }
                    break;
            }

            return messageResult;
        }

        private static bool IsMoveWithinBoard(int endPosX, int endPosY)
        {
            if ((0 <= endPosX && endPosX < 8) && (0 <= endPosY && endPosY < 8))
            {
                return true;
            }

            return false;
        }

        private static bool IsValidKingMove(int startPosX, int startPosY, int endPosX, int endPosY)
        {
            if ((startPosX == endPosX && startPosY + 1 == endPosY) ||
                (startPosX == endPosX && startPosY - 1 == endPosY) ||
                (startPosX + 1 == endPosX && startPosY == endPosY) ||
                (startPosX - 1 == endPosX && startPosY == endPosY) ||
                (startPosX + 1 == endPosX && startPosY + 1 == endPosY) ||
                (startPosX + 1 == endPosX && startPosY - 1 == endPosY) ||
                (startPosX - 1 == endPosX && startPosY + 1 == endPosY) ||
                (startPosX - 1 == endPosX && startPosY - 1 == endPosY))
            {
                return true;
            }

            return false;
        }

        private static bool IsValidRookMove(int startPosX, int startPosY, int endPosX, int endPosY)
        {
            if((startPosX == endPosX && startPosY != endPosY) ||
                (startPosX != endPosX && startPosY == endPosY))
            {
                return true;
            }

            return false;
        }

        private static bool IsValidBishopMove(int startPosX, int startPosY, int endPosX, int endPosY)
        {
            if (Math.Abs(startPosX - endPosX) == Math.Abs(startPosY - endPosY))
            {
                return true;
            }

            return false;
        }
    }
}
