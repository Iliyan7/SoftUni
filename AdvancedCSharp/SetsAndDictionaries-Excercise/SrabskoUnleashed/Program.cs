using System;
using System.Collections.Generic;
using System.Linq;

namespace SrabskoUnleashed
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var concerts = new Dictionary<string, Dictionary<string, int>>();

            while (input != "End")
            {
                var firstTokens = input.Split(new string[] { " @" }, StringSplitOptions.RemoveEmptyEntries);

                if(firstTokens.Length != 2)
                {
                    input = Console.ReadLine();
                    continue;
                }

                var secondTokens = firstTokens[1]
                    .Split(' ');


                var singer = firstTokens[0];

                var ticketsPrice = 0;
                var isPriceValid = int.TryParse(secondTokens[secondTokens.Length - 2], out ticketsPrice);

                var ticketsCount = 0;
                var isCountValid = int.TryParse(secondTokens[secondTokens.Length - 1], out ticketsCount);

                if (!(isPriceValid && isPriceValid))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var venue = string.Join(" ", secondTokens.Take(secondTokens.Length - 2));

                if (!concerts.ContainsKey(venue))
                {
                    concerts.Add(venue, new Dictionary<string, int> { { singer, ticketsPrice * ticketsCount } });
                }
                else
                {
                    if (!concerts[venue].ContainsKey(singer))
                    {
                        concerts[venue].Add(singer, 0);
                    }

                    concerts[venue][singer] += ticketsPrice * ticketsCount;
                }

                input = Console.ReadLine();
            }

            foreach (var venue in concerts)
            {
                Console.WriteLine(venue.Key);

                foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }
            }
        }
    }
}
