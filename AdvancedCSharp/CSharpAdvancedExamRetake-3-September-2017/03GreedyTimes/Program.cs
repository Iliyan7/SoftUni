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
                var amount = long.Parse(content[i + 1]);

                if (!bag.ContainsKey(type))
                {
                    continue;
                }

                if (IsBagCapacityReached(bagCapacity, type, amount))
                {
                    continue;
                }

                if (!CanGather(type, amount))
                {
                    continue;
                }

                if (bag[type].ContainsKey(item))
                {
                    bag[type][item] += amount;
                }
                else
                {
                    bag[type].Add(item, amount);
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
            else if (size > 3 && item.Substring(size - 3).Equals("gem"))
            {
                return "Gem";
            }
            else if (item.Equals("gold"))
            {
                return "Gold";
            }

            return "junk";
        }

        private static bool IsBagCapacityReached(long bagCapacity, string type, long amount)
        {
            return bag[type].Values.Sum() + amount > bagCapacity;
        }

        private static bool CanGather(string type, long amount)
        {
            if (type.Equals("Gold"))
            {
                return true;
            }
            else if (type.Equals("Gem") && bag["Gold"].Values.Sum() >= bag[type].Values.Sum() + amount)
            {
                return true;
            }
            else if (type.Equals("Cash") && bag["Gem"].Values.Sum() >= bag[type].Values.Sum() + amount)
            {
                return true;
            }

            return false;
        }
    }
}
