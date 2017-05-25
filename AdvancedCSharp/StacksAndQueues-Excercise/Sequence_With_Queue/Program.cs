using System;
using System.Collections.Generic;

namespace Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var currentQueue = new Queue<long>();
            queue.Enqueue(n);
            currentQueue.Enqueue(n);

            while(true)
            {
                var prevNum = currentQueue.Dequeue();

                queue.Enqueue(prevNum + 1);
                currentQueue.Enqueue(prevNum + 1);

                if (queue.Count >= 50)
                    break;

                queue.Enqueue(2  * prevNum + 1);
                currentQueue.Enqueue(2 * prevNum + 1);

                queue.Enqueue(prevNum + 2);
                currentQueue.Enqueue(prevNum + 2);
            }

            Console.WriteLine(string.Join(" ", queue));
        }
    }
}
