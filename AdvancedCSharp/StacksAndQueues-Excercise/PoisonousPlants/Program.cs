using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var deathDays = new int[n];
            var stack = new Stack<int>();

            stack.Push(0);

            for (int i = 1; i < n; i++)
            {
                var lastDay = 0;

                while (stack.Count() > 0 && plants[stack.Peek()] >= plants[i])
                {
                    lastDay = Math.Max(lastDay, deathDays[stack.Pop()]);
                }

                if(stack.Count > 0)
                {
                    deathDays[i] = lastDay + 1;
                }

                stack.Push(i);
            }

            Console.WriteLine(deathDays.Max());
        }
    }
}
