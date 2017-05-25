using System;
using System.Collections.Generic;

namespace HotPotato
{
    public class HotPotato
    {
        public static void Main()
        {
            var kids = Console.ReadLine().Split(' ');
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(kids);

            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine("Removed {0}", queue.Dequeue());
            }
            Console.WriteLine("Last is {0}", queue.Dequeue());

        }
    }
}