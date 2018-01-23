using System;
using System.Text.RegularExpressions;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            var surface1 = Console.ReadLine();
            var mantel1 = Console.ReadLine();
            var core = Console.ReadLine();
            var mantel2 = Console.ReadLine();
            var surface2 = Console.ReadLine();

            var coreLen = 0;

            if (IsValidSurface(surface1) && IsValidSurface(surface2)
                && IsValidMantel(mantel1) && IsValidMantel(mantel2)
                && IsValidCore(core, out coreLen))
            {
                Console.WriteLine("Valid");
                Console.WriteLine(coreLen);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

        private static bool IsValidSurface(string surface)
        {
            return Regex.IsMatch(surface, @"^[^a-zA-Z0-9]+$");
        }

        private static bool IsValidMantel(string mantel)
        {
            return Regex.IsMatch(mantel, @"^[0-9_]+$");
        }

        private static bool IsValidCore(string core, out int coreLen)
        {
            var regex = new Regex(@"^[^a-zA-Z0-9]+?[0-9_]+?([a-zA-Z]+)[0-9_]+?[^a-zA-Z0-9]+?$");
            Match match = regex.Match(core);

            coreLen = match.Groups[1].Value.Length;

            return match.Success;
        }
    }
}
