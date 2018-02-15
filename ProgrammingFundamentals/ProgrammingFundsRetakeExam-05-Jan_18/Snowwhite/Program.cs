using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new List<Dwarf>();
            Dictionary<string, int> colorsCount = new Dictionary<string, int>();

            Regex regex = new Regex(@"([^\s<:>]+)\s<:>\s([^\s<:>]+)\s<:>\s(\d+)");

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                Match inputMatch = regex.Match(input);

                var dwarfName = inputMatch.Groups[1].Value;
                var dwarfHatColor = inputMatch.Groups[2].Value;
                var dwarfPhysics = int.Parse(inputMatch.Groups[3].Value);

                var dwarf = dwarfs.SingleOrDefault(d => d.Name == dwarfName && d.HatColor == dwarfHatColor);
                if (dwarf == null)
                {
                    dwarfs.Add(new Dwarf(dwarfName, dwarfHatColor, dwarfPhysics));
                    if (!colorsCount.ContainsKey(dwarfHatColor))
                    {
                        colorsCount.Add(dwarfHatColor, 0);
                    }
                    colorsCount[dwarfHatColor]++;
                }
                else if (dwarf.Physics < dwarfPhysics)
                {
                    dwarf.Physics = dwarfPhysics;
                }
            }

            foreach (var dwarf in dwarfs.OrderByDescending(d => d.Physics).ThenByDescending(d => colorsCount[d.HatColor]))
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }

        public class Dwarf
        {
            public Dwarf(string name, string hatColor, int physics)
            {
                this.Name = name;
                this.HatColor = hatColor;
                this.Physics = physics;
            }

            public string Name { get; set; }

            public string HatColor { get; set; }

            public int Physics { get; set; }
        }
    }
}
