using System;
using System.Collections.Generic;

namespace Phonebook
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var phonebook = new Dictionary<string, string>();

            while (input != "search")
            {
                var args = input.Split('-');

                if (!phonebook.ContainsKey(args[0]))
                    phonebook.Add(args[0], String.Empty);

                phonebook[args[0]] = args[1];

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                var name = input;

                if (phonebook.ContainsKey(name))
                {
                    Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", name);
                }

                input = Console.ReadLine();
            }
        }
    }
}
