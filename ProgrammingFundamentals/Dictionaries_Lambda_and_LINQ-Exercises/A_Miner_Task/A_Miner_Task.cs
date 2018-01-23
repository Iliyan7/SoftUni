using System;
using System.Collections.Generic;

namespace A_Miner_Task
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, long> resourses = new Dictionary<string, long>();

            while (true)
            {
                string resourse = Console.ReadLine();

                if (resourse == "stop")
                    break;

                int quantity = int.Parse(Console.ReadLine());

                if (!resourses.ContainsKey(resourse))
                    resourses.Add(resourse, 0);

                resourses[resourse] += quantity;
            }

            foreach (KeyValuePair<string, long> pair in resourses)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
