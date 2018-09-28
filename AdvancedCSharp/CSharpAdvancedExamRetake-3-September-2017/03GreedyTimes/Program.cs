using System;
using System.Collections.Generic;
using System.Linq;

namespace _03GreedyTimes
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, long>> bag;

        public static void Main()
        {
            bag = new Dictionary<string, Dictionary<string, long>>()
            {
                { "Gold", new Dictionary<string, long>() },
                { "Gem", new Dictionary<string, long>() },
                { "Cash", new Dictionary<string, long>() }
            };

            var bagCapacity = long.Parse(Console.ReadLine());

            var content = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < content.Length - 1; i += 2)
            {
                var item = content[i];
                var type = GetItemType(item.ToLower());
                var quantity = long.Parse(content[i + 1]);

                if (!bag.ContainsKey(type))
                {
                    continue;
                }

                if (IsBagCapacityReached(bagCapacity, type, quantity))
                {
                    continue;
                }

                if (!CanGather(type, quantity))
                {
                    continue;
                }

                if (bag[type].ContainsKey(item))
                {
                    bag[type][item] += quantity;
                }
                else
                {
                    bag[type].Add(item, quantity);
                }
            }

            foreach (var type in bag.Where(b => b.Value.Count != 0).OrderByDescending(b => b.Value.Values.Sum()))
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");

                foreach (var item in type.Value.OrderByDescending(i => i.Key).ThenBy(a => a.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static string GetItemType(string item)
        {
            var size = item.Length;

            if (size == 3 && char.IsLetter(item[0]) && char.IsLetter(item[1]) && char.IsLetter(item[2]))
            {
                return "Cash";
            }
            
            else if (item.EndsWith("gem") && size > 3)
            {
                return "Gem";
            }
            else if (item.Equals("gold"))
            {
                return "Gold";
            }

            return "Junk";
        }

        private static bool IsBagCapacityReached(long bagCapacity, string type, long quantity)
        {
            return bag.Values.Sum(b => b.Values.Sum()) + quantity > bagCapacity;
        }

        private static bool CanGather(string type, long quantity)
        {
            if (type.Equals("Gold"))
            {
                return true;
            }
            else if (type.Equals("Gem") && bag["Gold"].Values.Sum() >= bag[type].Values.Sum() + quantity)
            {
                return true;
            }
            else if (type.Equals("Cash") && bag["Gem"].Values.Sum() >= bag[type].Values.Sum() + quantity)
            {
                return true;
            }

            return false;
        }
    }
}
