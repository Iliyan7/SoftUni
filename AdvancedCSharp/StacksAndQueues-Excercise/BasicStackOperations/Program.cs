using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    public class Program
    {
        public static void Main()
        {
            var inputOne = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var inputTwo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(inputTwo);

            int i = 0;
            while(i++ < inputOne[1])
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            if (stack.Contains(inputOne[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
