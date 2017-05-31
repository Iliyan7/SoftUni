using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationCounter
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var populationData = new Dictionary<string, Dictionary<string, long>>();

            while(input != "report")
            {
                var args = input.Split('|');

                var city = args[0];
                var country = args[1];
                var population = long.Parse(args[2]);

                if (!populationData.ContainsKey(country))
                {
                    populationData.Add(country, new Dictionary<string, long>() { { city, population } });
                }
                else
                {
                        populationData[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            foreach (var country in populationData.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine("{0} (total population: {1})", country.Key, country.Value.Values.Sum());

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                } 
            }
        }
    }
}
