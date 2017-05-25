using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyGraduation
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var students = new SortedDictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var grades = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                students.Add(name, grades);
            }

            foreach (var pair in students)
            {
                Console.WriteLine("{0} is graduated with {1}", pair.Key, pair.Value.Average());
            }
        }
    }
}
