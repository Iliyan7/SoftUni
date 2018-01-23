using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowman
{
    class Program
    {
        public static void Main()
        {
            var snowman = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var losedSnowman = new SortedSet<int>();

            while (snowman.Count > 1)
            {
                for (int i = 0; i < snowman.Count; i++)
                {
                    var attackerIndex = i;
                    var targetIndex = snowman[attackerIndex] % snowman.Count;

                    if (losedSnowman.Contains(attackerIndex) || losedSnowman.Contains(targetIndex))
                        continue;

                    var difference = Math.Abs(attackerIndex - targetIndex);

                    if (difference == 0) // equal, attacker suicide
                    {
                        losedSnowman.Add(attackerIndex);
                        Console.WriteLine($"{attackerIndex} performed harakiri");
                    }
                    else if (difference % 2 == 0) // Even, attacker wins
                    {
                        losedSnowman.Add(targetIndex);
                        Console.WriteLine($"{attackerIndex} x {targetIndex} -> {attackerIndex} wins");
                    }
                    else // odd, target wins
                    {
                        losedSnowman.Add(attackerIndex);
                        Console.WriteLine($"{attackerIndex} x {targetIndex} -> {targetIndex} wins");
                    }
                }

                foreach (var snowmenIndex in losedSnowman.Reverse())
                {
                    snowman.RemoveAt(snowmenIndex);
                }

                losedSnowman.Clear();
            }
        }
    }
}