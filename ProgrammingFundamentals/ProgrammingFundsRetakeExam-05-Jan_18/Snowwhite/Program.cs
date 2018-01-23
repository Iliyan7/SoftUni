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
            var dwarfs = new Dictionary<string, Dictionary<string, int>>();
            var input = string.Empty;

            Regex regex = new Regex(@"([^\s<:>]+)\s<:>\s([^\s<:>]+)\s<:>\s(\d+)");

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                Match inputMatch = regex.Match(input);

                var dwarfName = inputMatch.Groups[1].Value;
                var dwarfHatColor = inputMatch.Groups[2].Value;
                var dwarfPhysics = int.Parse(inputMatch.Groups[3].Value);

                if (dwarfs.ContainsKey(dwarfHatColor))
                {
                    if (dwarfs[dwarfHatColor].ContainsKey(dwarfName))
                    {
                        if (dwarfs[dwarfHatColor][dwarfName] < dwarfPhysics)
                        {
                            dwarfs[dwarfHatColor][dwarfName] = dwarfPhysics;
                        }
                    }
                    else
                    {
                        dwarfs[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                    }
                }
                else
                {
                    dwarfs.Add(dwarfHatColor, new Dictionary<string, int>()
                    {
                        { dwarfName, dwarfPhysics }
                    });
                }
            }

            foreach (var d in dwarfs.OrderByDescending(d => d.Value.Count()))
            {
                foreach (var dd in d.Value.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"{d.Key} {dd.key} <-> {dd.value}");
                }
            }

            //foreach (var d in dwarfs.Values.OrderByDescending(d => d.Values))
            //{
            //    foreach (var dd in d)
            //    {
            //        Console.WriteLine($"{dd.Key} {dd.Value} <-> {dd.Value}");
            //    }
            //}
        }
    }
}
