using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Armada
{
    public class Legions
    {
        public int LastActivity { get; set; }
        public Dictionary<string, long> SoliderTypeAndCount { get; set; }
    }

    public class Hornet_Armada
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var separators = new char[] { '=', '-', '>', ':', ' ' };
            //var separators = new string[] { " = ", " -> ", ":", };

            var legions = new Dictionary<string, Legions>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                var lastActivity = int.Parse(input[0]);
                var legionName = input[1].Trim();
                var soliderType = input[2].Trim();
                var soliderCount = long.Parse(input[3]);

                if (!legions.ContainsKey(legionName))
                {
                    var soliderTypeAndCount = new Dictionary<string, long>();
                    soliderTypeAndCount.Add(soliderType, soliderCount);

                    legions.Add(legionName, new Legions
                    {
                        LastActivity = lastActivity,
                        SoliderTypeAndCount = soliderTypeAndCount
                    });
                }
                else
                {
                    if(!legions[legionName].SoliderTypeAndCount.ContainsKey(soliderType))
                    {
                        legions[legionName].SoliderTypeAndCount.Add(soliderType, soliderCount);
                    }
                    else
                    {
                        legions[legionName].SoliderTypeAndCount[soliderType] += soliderCount;
                    }

                    legions[legionName].LastActivity = Math.Max(lastActivity, legions[legionName].LastActivity);
                }
            }

            var input2 = Console.ReadLine().Split(new char[] { '\\' }, 2);

            if (input2.Length > 1)
            {
                var activicty = int.Parse(input2[0]);
                var soliderType = input2[1];

                var filteredLegion = GetFilteredLegions(legions, activicty, soliderType);

                foreach (var pair in filteredLegion.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                }
            }
            else
            {
                var soliderType = input2[0];

                foreach (var legion in legions.OrderByDescending(x => x.Value.LastActivity))
                {
                    if(legion.Value.SoliderTypeAndCount.ContainsKey(soliderType))
                        Console.WriteLine("{0} : {1}", legion.Value.LastActivity,  legion.Key);
                }
            }
        }

        private static Dictionary<string, long> GetFilteredLegions(Dictionary<string, Legions> legions, int activicty, string soliderType)
        {
            var tempDic = new Dictionary<string, long>();

            foreach (var legion in legions)
            {
                if (legion.Value.LastActivity < activicty)
                {
                    var sum = 0L;

                    foreach (var soliderPair in legion.Value.SoliderTypeAndCount)
                    {
                        if (soliderPair.Key == soliderType)
                        {
                            sum += soliderPair.Value;
                        }
                    }

                    tempDic.Add(legion.Key, sum);
                }
            }

            return tempDic;
        }
    }
}
