using System;
using System.Linq;

namespace Ladybugs
{
    public class Ladybugs
    {
        public static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            var ladybugIndexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var field = new int[fieldSize];
            FillFieldWithLadybugs(ladybugIndexes, field);

            while (true)
            {
                var commands = Console.ReadLine().Split(' ');

                if (commands[0] == "end")
                    break;

                var ladybugIndex = int.Parse(commands[0]);
                var direction = commands[1];
                var flyLenght = int.Parse(commands[2]);

                if (!IsLadybugValid(ladybugIndex, fieldSize))
                    continue;

                if (field[ladybugIndex] == 0)
                    continue;

                if (direction == "left")
                    MoveLeft(ladybugIndex, flyLenght, field);
                else if (direction == "right")
                    MoveRight(ladybugIndex, flyLenght, field);
            }

            for (int i = 0; i < field.Length; i++)
            {
                Console.Write("{0} ", field[i] == 1 ? 1 : 0);
            }

            Console.WriteLine();
        }

        public static void FillFieldWithLadybugs(int[] ladybugIndexes, int[] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                if (ladybugIndexes.Contains(i))
                    field[i] = 1;
            }
        }

        public static bool IsLadybugValid(int ladybugIndex, int fieldSize)
        {
            if (0 <= ladybugIndex && ladybugIndex < fieldSize)
                return true;

            return false;
        }

        public static void MoveLeft(int ladybugIndex, int flyLenght, int[] field)
        {
            field[ladybugIndex] = 0;

            var pos = ladybugIndex - flyLenght;

            while (true)
            {
                if (!IsLadybugValid(pos, field.Length))
                    break;

                if (field[pos] == 0)
                {
                    field[pos] = 1;
                    break;
                }

                pos -= flyLenght;
            }
        }

        public static void MoveRight(int ladybugIndex, int flyLenght, int[] field)
        {
            field[ladybugIndex] = 0;

            var pos = ladybugIndex + flyLenght;

            while (true)
            {
                if (!IsLadybugValid(pos, field.Length))
                    break;

                if (field[pos] == 0)
                {
                    field[pos] = 1;
                    break;
                }

                pos += flyLenght;
            }
        }
    }
}
