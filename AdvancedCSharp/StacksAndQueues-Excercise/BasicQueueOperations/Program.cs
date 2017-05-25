using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
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

            var queue = new Queue<int>(inputTwo);

            int i = 0;
            while (i++ < inputOne[1])
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            if (queue.Contains(inputOne[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
