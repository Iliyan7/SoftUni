using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    public class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if(c == '(')
                {
                    stack.Push(i);
                }
                else if(c == ')')
                {
                    int startIndex = stack.Pop();

                    Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                }
            }


        }
    }
}
