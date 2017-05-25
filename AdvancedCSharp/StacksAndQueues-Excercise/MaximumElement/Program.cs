using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>(n);
            var max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var query = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                switch (query[0])
                {
                    case 1:
                        {
                            var num = query[1];
                            stack.Push(num);
                            if (num > max)
                            {
                                max = num;
                            }
                            break;
                        }

                    case 2:
                        {
                            var popped = stack.Pop();
                            if (popped == max)
                                max = stack.Count > 0 ? stack.Max() : int.MinValue;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(max);
                            break;
                        }
                }
            }
        }
    }
}
