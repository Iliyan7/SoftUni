using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogs
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var logs = new SortedDictionary<string, Dictionary<string, int>>();

            while(input != "end")
            {
                var args = input.Split(' ');
                var ip = args[0].Substring(3);
                var username = args[2].Substring(5);

                if(!logs.ContainsKey(username))
                {
                    logs.Add(username, new Dictionary<string, int>() { { ip, 1 } });
                }
                else
                {
                    if (!logs[username].ContainsKey(ip))
                        logs[username].Add(ip, 0);

                    logs[username][ip]++;
                }

                input = Console.ReadLine();
            }

            foreach (var log in logs)
            {
                Console.WriteLine("{0}:", log.Key);

                var ipCollection = log
                    .Value
                    .Select(x => $"{x.Key} => {x.Value}");

                Console.WriteLine("{0}.", string.Join(", ", ipCollection));
            }
        }
    }
}
