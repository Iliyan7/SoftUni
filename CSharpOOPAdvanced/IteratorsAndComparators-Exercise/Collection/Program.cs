using System;
using System.Linq;

namespace Collection
{
    class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Skip(1)
                .ToList();

            var list = new ListyIterator<string>(input);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    switch (command)
                    {
                        case "Move": Console.WriteLine(list.Move()); break;
                        case "HasNext": Console.WriteLine(list.HasNext()); break;
                        case "Print": list.Print(); break;
                        case "PrintAll": list.PrintAll(); break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
