using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsResults
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var studentResults = new Dictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(new string[] { " - " }, StringSplitOptions.None);

                var name = args[0];

                var grades = args[1]
                    .Split(new string[] { ", " }, StringSplitOptions.None)
                    .Select(double.Parse)
                    .ToArray();

                studentResults.Add(name, grades);
            }

            Console.WriteLine("{0, -10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");

            foreach (var result in studentResults)
            {
                Console.WriteLine("{0, -10}|{1,7:F2}|{2,7:F2}|{3,7:F2}|{4,7:F4}|", result.Key, result.Value[0], result.Value[1], result.Value[2], result.Value.Average());
            }
        }
    }
}
