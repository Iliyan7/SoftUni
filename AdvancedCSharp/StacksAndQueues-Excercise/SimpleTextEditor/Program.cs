using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();
            var text = String.Empty;
            stack.Push(text);

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (args[0])
                {
                    case "1":
                        {
                            text += args[1];
                            stack.Push(text);
                            break;
                        }
                    case "2":
                        {
                            var count = int.Parse(args[1]);

                            text = text.Remove(text.Length - count, count);
                            stack.Push(text);

                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(text[int.Parse(args[1]) - 1]);
                            break;
                        }
                    case "4":
                        {
                            stack.Pop();
                            text = stack.Peek();

                            break;
                        }
                }
            }
        }
    }
}
