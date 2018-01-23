using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    public class Nether_Realms
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();

            var demons = new Dictionary<string, Demon>();

            for (int i = 0; i < names.Length; i++)
            {
                var name = names[i];

                var health = GetDemonHealth(name);
                var damage = GetDemonDamage(name);

                var demon = new Demon()
                {
                    Health = health,
                    Damage = damage
                };

                demons.Add(name, demon);
            }

            foreach (var demon in demons.OrderBy(x => x.Key))
            {
                Console.WriteLine("{0} - {1} health, {2:F2} damage", demon.Key, demon.Value.Health, demon.Value.Damage);
            }
        }

        public static int GetDemonHealth(string name)
        {
            var health = 0;

            for (int i = 0; i < name.Length; i++)
            {
                if (IsContainsForbiddenChars(name[i]))
                    continue;

                health += name[i];
            }

            return health;
        }

        private static bool IsContainsForbiddenChars(char c)
        {
            var forbiddenChars = new char[] { '+', '-', '*', '/', '.' };

            foreach (var fc in forbiddenChars)
            {
                if (char.IsDigit(c) || fc == c)
                    return true;
            }

            return false;
        }

        public static double GetDemonDamage(string name)
        {
            var regex = new Regex(@"[+-]?\d+(?:\.?\d+)?");

            var matches = regex.Matches(name);

            var damage = 0D;

            foreach (Match match in matches)
            {
                damage += double.Parse(match.Value);
            }

            var modifiers = name.Where(x => x == '*' || x == '/').ToArray();

            foreach (var modifier in modifiers)
            {
                if (modifier == '*')
                    damage *= 2;
                else
                    damage /= 2;
            }

            return damage;
        }
    }
}
