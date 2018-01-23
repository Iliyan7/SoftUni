using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberWars
{
    public class Program
    {
        enum Result
        {
            None = 0,
            FirstPlayerWin,
            SecondPlayerWin,
            ItsDraw
        };

        private static Result GameResult = Result.None;
        private static List<string> CardsOnField = new List<string>();

        public static void Main()
        {
            var firstPlayerCards = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var secondPlayerCards = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var firstQueue = new Queue<string>(firstPlayerCards);
            var secondQueue = new Queue<string>(secondPlayerCards);

            var turns = 0;

            while (true)
            {
                turns++;

                var firstPlayerCard = firstQueue.Dequeue();
                var secondPlayerCard = secondQueue.Dequeue();

                var firstPlayerCardNumber = int.Parse(Regex.Match(firstPlayerCard, @"\d+").Value);
                var secondPlayerCardNumber = int.Parse(Regex.Match(secondPlayerCard, @"\d+").Value);

                if (firstPlayerCardNumber > secondPlayerCardNumber)
                {
                    firstQueue.Enqueue(firstPlayerCard);
                    firstQueue.Enqueue(secondPlayerCard);
                }
                else if (firstPlayerCardNumber < secondPlayerCardNumber)
                {
                    secondQueue.Enqueue(secondPlayerCard);
                    secondQueue.Enqueue(firstPlayerCard);
                }
                else
                {
                    CheckFor3MoreCards(firstQueue, secondQueue);
                }

                if (GameResult != Result.None)
                    return;

                if (firstQueue.Count == 0)
                {
                    GameResult = Result.SecondPlayerWin;
                    break;
                }

                if (secondQueue.Count == 0)
                {
                    GameResult = Result.FirstPlayerWin;
                    break;
                }
            }

            var result = String.Empty;

            switch (GameResult)
            {
                case Result.FirstPlayerWin: result = "First player wins"; break;
                case Result.SecondPlayerWin: result = "Second player wins"; break;
                case Result.ItsDraw: result = "Draw"; break;
            }

            Console.WriteLine("{0} after {1} turns", result, turns);
        }

        private static void CheckFor3MoreCards(Queue<string> firstQueue, Queue<string> secondQueue)
        {
            if (firstQueue.Count < 3 && secondQueue.Count < 3)
            {
                GameResult = Result.ItsDraw;
                return;
            }

            if (firstQueue.Count < 3)
            {
                GameResult = Result.SecondPlayerWin;
                return;
            }

            if (secondQueue.Count < 3)
            {
                GameResult = Result.FirstPlayerWin;
                return;
            }

            var firstPlayerCardsSum = 0;
            var secondPlayerCardsSum = 0;

            for (int i = 0; i < 3; i++)
            {
                firstPlayerCardsSum += GetCardLetterNumber(firstQueue);
                secondPlayerCardsSum += GetCardLetterNumber(secondQueue);
            }

            if (firstPlayerCardsSum < secondPlayerCardsSum)
            {
                SortAddToPlayerAndClearCardsOnField(CardsOnField, secondQueue);
            }
            else if (firstPlayerCardsSum > secondPlayerCardsSum)
            {
                SortAddToPlayerAndClearCardsOnField(CardsOnField, firstQueue);
            }
            else
            {
                CheckFor3MoreCards(firstQueue, secondQueue);
            }
        }

        private static int GetCardLetterNumber(Queue<string> queue)
        {
            var card = queue.Dequeue();
            CardsOnField.Add(card);

            var letter = card.Last();

            return int.Parse((letter - '`').ToString());
        }

        private static void SortAddToPlayerAndClearCardsOnField(List<string> cardsOnField, Queue<string> queue)
        {
            var sortedCards = cardsOnField
                .OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1)))
                .ThenByDescending(x => x.Last().ToString())
                .ToList();

            foreach (var card in sortedCards)
            {
                queue.Enqueue(card);
            }

            cardsOnField.Clear();
        }
    }
}
