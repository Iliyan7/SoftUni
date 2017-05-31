using System;
using System.Collections.Generic;
using System.Linq;

namespace LogsAggregator
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var durationLog = new SortedDictionary<string, int>();
            var ipsLog = new SortedDictionary<string, SortedSet<string>>();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                var ip = args[0];
                var user = args[1];
                var duration = int.Parse(args[2]);

                if(!durationLog.ContainsKey(user))
                {
                    durationLog.Add(user, duration);
                    ipsLog.Add(user, new SortedSet<string> { ip });
                }
                else
                {
                    durationLog[user] += duration;
                    ipsLog[user].Add(ip);
                }
            }

            foreach (var log in durationLog)
            {
                Console.Write("{0}: {1} ", log.Key, log.Value);

                var ip = ipsLog
                    .First(x => x.Key == log.Key);

                Console.WriteLine("[{0}]", string.Join(", ", ip.Value));
            }
        }
    }
}
