using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    class Program
    {
        public static void Main()
        {
            var listOfBoxes = new List<Box<int>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new Box<int>(int.Parse(Console.ReadLine()));
                listOfBoxes.Add(box);
            }

            var indexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            SwapElements(listOfBoxes, indexes[0], indexes[1]);

            foreach (var box in listOfBoxes)
            {
                Console.WriteLine(box);
            }
        }

        private static void SwapElements<T>(List<T> listOfBoxes, int index1, int index2)
        {
            T tempBox = listOfBoxes[index1];
            listOfBoxes[index1] = listOfBoxes[index2];
            listOfBoxes[index2] = tempBox;
        }
    }
}
