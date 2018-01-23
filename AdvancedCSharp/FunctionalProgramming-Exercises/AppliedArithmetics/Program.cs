using System;
using System.Linq;

namespace AppliedArithmetics
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var command = String.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if(command != "print")
                {
                    Func<int, int> func = GetFunc(command);

                    numbers = numbers
                        .Select(func)
                        .ToArray();
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }

        private static Func<int, int> GetFunc(string command)
        {
            switch (command)
            {
                case "add":
                    {
                        return n => n + 1;
                    }
                case "multiply":
                    {
                        return n => n * 2;
                    }
                case "subtract":
                    {
                        return n => n - 1;
                    }
                default:
                    return n => n;
            }
        }
    }
}
