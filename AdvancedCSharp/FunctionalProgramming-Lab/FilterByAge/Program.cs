using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var peoples = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var nameAndAge = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                peoples.Add(nameAndAge[0], int.Parse(nameAndAge[1]));
            }

            var youngerOrOlder = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine()
                .Split(' ');

            //  --- Build-in ---
            //if (youngerOrOlder == "younger")
            //{
            //    peoples = peoples
            //        .Where(p => p.Value < age)
            //        .ToDictionary(k => k.Key, v => v.Value);
            //}
            //else
            //{
            //    peoples = peoples
            //       .Where(p => p.Value >= age)
            //       .ToDictionary(k => k.Key, v => v.Value);
            //}

            // --- OR Custom Func ---
            Func<KeyValuePair<string, int>, bool> tester = TestCondition(youngerOrOlder, age);

            peoples = peoples
                .Where(tester)
                .ToDictionary(k => k.Key, v => v.Value);

            // --- Printing ---
            if (format.Length == 1)
            {
                foreach (var people in format[0] == "name" ? peoples.Keys : peoples.Values.Select(x => x.ToString()))
                {
                    Console.WriteLine(people);
                }
            }
            else
            {
                foreach (var people in peoples)
                {
                    Console.WriteLine("{0} - {1}", people.Key, people.Value);
                }
            }
        }

        public static Func<KeyValuePair<string, int>, bool> TestCondition(string condition, int age)
        {
            switch(condition)
            {
                case "younger": return x => x.Value < age;
                case "older": return x => x.Value >= age;
                default: return null;
            }
        }
    }
}
