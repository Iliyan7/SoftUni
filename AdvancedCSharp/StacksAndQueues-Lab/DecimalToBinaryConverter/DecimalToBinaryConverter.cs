using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            if(n == 0)
            {
                Console.Write(n);
            }
            else
            {
                while(n != 0)
                {
                    stack.Push(n % 2);
                    n = n / 2;
                }

                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop());
                }
            }

            Console.WriteLine();
        }
    }
}
