using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var stack = new Stack<string>(input.Length);

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            while (stack.Count > 1)
            {
                var leftNum = int.Parse(stack.Pop());
                var op = stack.Pop();
                var rightNum = int.Parse(stack.Pop());

                if(op == "+")
                {
                    leftNum = leftNum + rightNum;
                    stack.Push(leftNum.ToString());
                }
                else
                {
                    leftNum = leftNum - rightNum;
                    stack.Push(leftNum.ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
