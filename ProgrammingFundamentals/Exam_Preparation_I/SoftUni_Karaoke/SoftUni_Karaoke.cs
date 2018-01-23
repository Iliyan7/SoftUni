using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Karaoke
{
    public class SoftUni_Karaoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split(',').Select(p => p.Trim()).ToArray();
            var songs = Console.ReadLine().Split(',').Select(s => s.Trim()).ToArray();

            var stage = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine().Split(',').Select(p => p.Trim()).ToArray();
                var name = input[0];

                if (name == "dawn")
                    break;

                var song = input[1];
                var reward = input[2];

                if (participants.Any(p => p == name) && songs.Any(s => s == song))
                {
                    if (!stage.ContainsKey(name))
                    {
                        stage.Add(name, new List<string> { reward });
                    }
                    else
                    {
                        if (!stage.Values.SelectMany(x => x).Any(x => x == reward))
                            stage[name].Add(reward);
                    }
                }   
            }

            if(stage.Keys.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            foreach (var pair in stage.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0}: {1} awards", pair.Key, pair.Value.Count);

                foreach (var award in pair.Value.OrderBy(x => x))
                {
                    Console.WriteLine("--{0}", award);
                }
            }
        }
    }
}
