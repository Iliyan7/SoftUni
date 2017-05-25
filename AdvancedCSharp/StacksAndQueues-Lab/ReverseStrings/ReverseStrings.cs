using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    public class ReverseStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            foreach(char c in input)
            {
                stack.Push(c);
            }

            while(stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
