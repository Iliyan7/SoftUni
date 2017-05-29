using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();

                usernames.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
