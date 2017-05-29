using System;
using System.Collections.Generic;

namespace AMinersTask
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var resources = new Dictionary<string, int>();

            var i = 1;
            var resourse = String.Empty;

            while (input != "stop")
            {
                if (i % 2 != 0)
                {
                    resourse = input;

                    if(!resources.ContainsKey(resourse))
                        resources.Add(resourse, 0);
                }
                else
                {
                    resources[resourse] += int.Parse(input);
                }

                input = Console.ReadLine();
                i++;
            }

            foreach (var r in resources)
            {
                Console.WriteLine("{0} -> {1}", r.Key, r.Value);
            }
        }
    }
}
