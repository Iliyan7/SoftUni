using System;
using System.Linq;

namespace Array_Manipulator
{
    public class Array_Manipulator
    {
        public static void Main()
        {
            var arrSeq = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            while (true)
            {
                var commands = Console.ReadLine().Split();
                var end = false;

                switch (commands[0])
                {
                    case "exchange":
                        {
                            var index = int.Parse(commands[1]);
                            if (!(0 <= index && index < arrSeq.Length))
                            {
                                Console.WriteLine("Invalid index");
                                continue;
                            }

                            arrSeq = arrSeq.Skip(index + 1).Concat(arrSeq.Take(index + 1)).ToArray();

                            break;
                        }
                    case "max":
                    case "min":
                        {
                            Console.WriteLine(GetMaxMinIndex(arrSeq, commands[0], commands[1]));
                            break;
                        }
                    case "first":
                    case "last":
                        {
                            Console.WriteLine(GetFirstLastElements(arrSeq, commands[0], int.Parse(commands[1]), commands[2]));
                            break;
                        }
                    default: end = true; break;
                }

                if (end) break;
            }

            Console.WriteLine("[{0}]", string.Join(", ", arrSeq));
        }

        public static string GetMaxMinIndex(int[] arr, string maxOrMin, string evenOrOdd)
        {
            int remainder = evenOrOdd == "odd" ? 1 : 0;
            var filtered = arr.Where(n => n % 2 == remainder).ToArray();

            if (!filtered.Any())
            {
                return "No matches";
            }

            return maxOrMin == "min"
                ? Array.LastIndexOf(arr, filtered.Min()).ToString()
                : Array.LastIndexOf(arr, filtered.Max()).ToString();
        }

        public static string GetFirstLastElements(int[] arr, string firstOrLast, int count, string evenOrOdd)
        {
            if (count > arr.Length)
            {
                return "Invalid count";
            }

            int remainder = evenOrOdd == "odd" ? 1 : 0;
            var filtered = arr.Where(n => n % 2 == remainder).ToArray();

            return string.Format("[{0}]", firstOrLast == "first"
                ? string.Join(", ", filtered.Take(count))
                : string.Join(", ", filtered.Reverse().Take(count).Reverse()));
        }
    }
}
