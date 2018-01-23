using System;
using System.Linq;

namespace _Stack
{
    class Program
    {
        public static void Main()
        {
            var stack = new Stack<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var args = command
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (args[0].Equals("Push"))
                {
                    args = args
                        .Where((source, index) => index != 0)
                        .ToArray();

                    stack.Push(args);
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                }
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
