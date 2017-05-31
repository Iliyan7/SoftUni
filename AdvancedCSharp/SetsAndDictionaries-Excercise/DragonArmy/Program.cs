using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dragons = new Dictionary<string, SortedDictionary<string, int[]>>();

            var input = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                var args = input
                    .Split(' ');

                var type = args[0];
                var name = args[1];
                var damage = args[2] == "null" ? 45 : int.Parse(args[2]);
                var health = args[3] == "null" ? 250 : int.Parse(args[3]);
                var armor = args[4] == "null" ? 10 : int.Parse(args[4]);

                if(!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, int[]> { { name, new int[] { damage, health, armor } } });
                }
                else
                {
                    if (!dragons[type].ContainsKey(name))
                    {
                        dragons[type].Add(name, new int[] { 0, 0, 0 });
                    }

                    dragons[type][name][0] = damage;
                    dragons[type][name][1] = health;
                    dragons[type][name][2] = armor;
                }

                input = Console.ReadLine();
            }

            foreach (var type in dragons)
            {
                var stats = type.Value.Values.ToArray();
                
                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", type.Key, GetAverageDamage(stats, stats.Length), GetAverageHealth(stats, stats.Length), GetAverageArmor(stats, stats.Length));

                foreach (var name in type.Value)
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", name.Key, name.Value[0], name.Value[1], name.Value[2]);
                }
            }
        }

        private static double GetAverageDamage(int[][] stats, int length)
        {
            var damage = 0;

            for (int i = 0; i < length; i++)
            {
                damage += stats[i][0];
            }

            return damage / (double)length;
        }

        private static double GetAverageHealth(int[][] stats, int length)
        {
            var hp = 0;

            for (int i = 0; i < length; i++)
            {
                hp += stats[i][1];
            }

            return hp / (double)length;
        }

        private static double GetAverageArmor(int[][] stats, int length)
        {
            var armor = 0;

            for (int i = 0; i < length; i++)
            {
                armor += stats[i][2];
            }

            return armor / (double)length;
        } 
    }
}
