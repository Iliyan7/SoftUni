using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            var isBalanced = true;

            foreach (var bracket in input)
            {
                if(new char[] { '(', '{', '[' }.Contains(bracket))
                {
                    stack.Push(bracket);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    var ch = bracket;
                    SwapBracket(ref ch);

                    if (ch != stack.Pop())
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }

        private static void SwapBracket(ref char bracket)
        {
            switch(bracket)
            {
                case '(': bracket = ')'; break;
                case ')': bracket = '('; break;
                case '{': bracket = '}'; break;
                case '}': bracket = '{'; break;
                case '[': bracket = ']'; break;
                case ']': bracket = '['; break;
            }
        }
    }
}
