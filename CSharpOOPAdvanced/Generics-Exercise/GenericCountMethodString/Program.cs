﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodString
{
    class Program
    {
        public static void Main()
        {
            var listOfBoxes = new List<Box<string>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>(Console.ReadLine());
                listOfBoxes.Add(box);
            }

            var element = Console.ReadLine();

            Console.WriteLine(GetGreaterElementsCount(listOfBoxes, element));
        }

        private static int GetGreaterElementsCount<T>(List<Box<T>> listOfBoxes, T element)
            where T : IComparable<T>
        {
            return listOfBoxes.Count(b => b.Value.CompareTo(element) > 0);
        }
    }
}
