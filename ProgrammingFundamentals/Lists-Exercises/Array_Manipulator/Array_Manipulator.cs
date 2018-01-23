using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    public class Array_Manipulator
    {
        public static void Main()
        {
            List<int> intList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> containsNum = new List<int>();

            string command = String.Empty;

            while (command != "print")
            {
                string[] commands = Console.ReadLine().Split(' ');
                command = commands[0];

                switch (command)
                {
                    case "add":
                        {
                            intList.Insert(int.Parse(commands[1]), int.Parse(commands[2]));
                            break;
                        }
                    case "addMany":
                        {
                            List<string> tempList = new List<string>(commands.Skip(2));
                            intList.InsertRange(int.Parse(commands[1]), tempList.Select(x => int.Parse(x)));
                            break;
                        }

                    case "contains":
                        {
                            if (intList.Contains(int.Parse(commands[1])))
                                containsNum.Add(intList.IndexOf(int.Parse(commands[1])));
                            else
                                containsNum.Add(-1);

                            break;
                        }

                    case "remove":
                        {
                            intList.RemoveAt(int.Parse(commands[1]));
                            break;
                        }

                    case "shift":
                        {
                            ShiftList(intList, int.Parse(commands[1]));
                            break;
                        }

                    case "sumPairs":
                        {
                            SumPairs(intList);

                            break;
                        }

                    case "print":
                        {
                            if (containsNum.Count() != 0) Console.WriteLine(string.Join("\n", containsNum));
                            Console.WriteLine("[{0}]", string.Join(", ", intList));
                            break;
                        }

                    default:
                        break;
                }
            }
        }

        public static void ShiftList(List<int> list, int shift)
        {
            List<int> tempList = new List<int>(list);

            int oldIndex = 0;
            int len = list.Count();

            for (int i = 0; i < len; i++)
            {
                oldIndex = i + shift;
                list[i] = tempList[oldIndex % len];
            }
        }

        public static void SumPairs(List<int> list)
        {
            for (int i = 0; i < list.Count() - 1; i++)
            {
                list[i] = list[i] + list[i + 1];
                list.RemoveAt(i + 1);
            }
        }
    }
}
