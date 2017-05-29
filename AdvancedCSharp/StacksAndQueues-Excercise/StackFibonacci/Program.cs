using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFibonacci
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(GetFibonacci(int.Parse(Console.ReadLine())));
        }

        private static long GetFibonacci(int n)
        {
            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                var n2 = stack.Pop();
                var n1 = stack.Peek();
                stack.Push(n2);
                stack.Push(n1 + n2);
            }

            return stack.Pop();
        }
    }
}
