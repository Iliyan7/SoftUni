using System;
using System.Collections.Generic;
using System.Linq;

namespace LogsAggregator
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var legendaryMaterials = new Dictionary<string, int>();
            var junkMaterials = new Dictionary<string, int>();

            var legendaryData = new string[2][]
                {
                    new string[] { "Shadowmourne", "Valanyr", "Dragonwrath" },
                    new string[] { "shards", "fragments", "motes" }
                };

            var isFound = false;

            while (input.Length > 0)
            {
                var args = input.Split(' ');

                for (int i = 0; i < args.Length; i += 2)
                {
                    var quantity = int.Parse(args[i]);
                    var material = args[i + 1].ToLower();

                    if (legendaryData[1].Contains(material))
                    {
                        if (!legendaryMaterials.ContainsKey(material))
                            legendaryMaterials.Add(material, 0);

                        legendaryMaterials[material] += quantity;
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                            junkMaterials.Add(material, 0);

                        junkMaterials[material] += quantity;
                    }

                    if (CheckForLegendaryItem(legendaryMaterials, junkMaterials, legendaryData))
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                    break;

                input = Console.ReadLine();
            }
        }

        private static bool CheckForLegendaryItem(Dictionary<string, int> legendaryMaterials, Dictionary<string, int> junkMaterials, string[][] legendaryData)
        {
            var pair = legendaryMaterials
                .FirstOrDefault(x => x.Value >= 250);

            if (pair.Value != 0)
            {
                legendaryMaterials[pair.Key] -= 250;

                Console.WriteLine("{0} obtained!", legendaryData[0][Array.IndexOf(legendaryData[1], pair.Key)]);

                for (int i = 0; i < legendaryData[1].Length; i++)
                {
                    if (!legendaryMaterials.ContainsKey(legendaryData[1][i]))
                        legendaryMaterials.Add(legendaryData[1][i], 0);
                }

                foreach (var m in legendaryMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine("{0}: {1}", m.Key, m.Value);
                }

                foreach (var m in junkMaterials.OrderBy(x => x.Key))
                {
                    Console.WriteLine("{0}: {1}", m.Key, m.Value);
                }

                return true;
            }

            return false;
        }
    }
}