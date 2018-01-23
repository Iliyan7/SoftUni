using System;
using System.Collections.Generic;
using System.Linq;

namespace MapDistricts
{
    public class Program
    {
        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var cityPopulation = new Dictionary<string, List<long>>();

            foreach (var element in elements)
            {
                var info = element
                    .Split(':');

                var city = info[0];
                var population = int.Parse(info[1]);

                if(!cityPopulation.ContainsKey(city))
                {
                    cityPopulation.Add(city, new List<long>());
                }

                cityPopulation[city].Add(population);

            }

            var bound = long.Parse(Console.ReadLine());

            cityPopulation = cityPopulation
                .Where(c => c.Value.Sum() > bound)
                .OrderByDescending(c => c.Value.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var city in cityPopulation)
            {
                Console.WriteLine("{0}: {1}", city.Key, string.Join(" ", city.Value.OrderByDescending(x => x).Take(5)));
            }
        }
    }
}
