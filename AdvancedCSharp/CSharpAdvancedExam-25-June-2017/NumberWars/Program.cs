using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberWars
{
    public class Program
    {
        private const int MaxTurns = 1000000;

        private static Queue<KeyValuePair<int, char>> firstPlayerDeck = new Queue<KeyValuePair<int, char>>();
        private static Queue<KeyValuePair<int, char>> secondPlayerDeck = new Queue<KeyValuePair<int, char>>();

        private static List<KeyValuePair<int, char>> board = new List<KeyValuePair<int, char>>();

        private static bool gameOver;

        public static void Main()
        {
            InitDeck(firstPlayerDeck);
            InitDeck(secondPlayerDeck);

            int turns = 0;

            while (turns < MaxTurns || !gameOver)
            {
                if (firstPlayerDeck.Count == 0 || secondPlayerDeck.Count == 0)
                {
                    break;
                }

                var firstPlayerCard = firstPlayerDeck.Dequeue();
                var secondPlayerCard = secondPlayerDeck.Dequeue();

                board.Add(firstPlayerCard);
                board.Add(secondPlayerCard);

                CompareScore(firstPlayerCard.Key, secondPlayerCard.Key);

                turns++;
            }

            if (firstPlayerDeck.Count == secondPlayerDeck.Count)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else
            {
                Console.WriteLine($"{(firstPlayerDeck.Count > secondPlayerDeck.Count ? "First" : "Second")} player wins after {turns} turns");
            }
        }

        private static void InitDeck(Queue<KeyValuePair<int, char>> playerDeck)
        {
            var cards = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var regex = new Regex(@"([0-9]+)(\w)");

            foreach (var card in cards)
            {
                var match = regex.Match(card);
                var number = int.Parse(match.Groups[1].Value);
                var letter = char.Parse(match.Groups[2].Value);

                playerDeck.Enqueue(new KeyValuePair<int, char>(number, letter));
            }
        }

        private static void CompareScore(int firstPlayerScore, int secondPlayerScore)
        {
            if (firstPlayerScore > secondPlayerScore)
            {
                MoveCardsToWinnerDeck(firstPlayerDeck);
            }
            else if (firstPlayerScore < secondPlayerScore)
            {
                MoveCardsToWinnerDeck(secondPlayerDeck);
            }
            else
            {
                if (firstPlayerDeck.Count() < 3 || secondPlayerDeck.Count() < 3)
                {
                    gameOver = true;
                }
                else
                {
                    War();
                }
            }
        }

        private static void MoveCardsToWinnerDeck(Queue<KeyValuePair<int, char>> playerDeck)
        {
            var winnerCards = board
                .OrderByDescending(x => x.Key)
                .ThenByDescending(x => x.Value);

            foreach (var card in winnerCards)
            {
                playerDeck.Enqueue(card);
            }

            board.Clear();
        }

        private static void War()
        {
            var firstPlayerCardsSum = 0;
            var secondPlayerCardsSum = 0;

            for (int i = 0; i < 3; i++)
            {
                var firstPlayerCard = firstPlayerDeck.Dequeue();
                var secondPlayerCard = secondPlayerDeck.Dequeue();

                board.Add(firstPlayerCard);
                board.Add(secondPlayerCard);

                firstPlayerCardsSum += firstPlayerCard.Value - '`';
                secondPlayerCardsSum += secondPlayerCard.Value - '`';
            }

            CompareScore(firstPlayerCardsSum, secondPlayerCardsSum);
        }
    }
}
