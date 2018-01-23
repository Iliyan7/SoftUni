using System;
using System.Collections.Generic;
using System.Linq;

namespace Command_Interpreter
{
    public class Command_Interpreter
    {
        public static void Main()
        {
            var stringList = Console.ReadLine().Split(' ').ToList();

            while (true)
            {
                var commands = Console.ReadLine().Split(' ');

                if (commands[0] == "end")
                    break;

                switch (commands[0])
                {
                    case "reverse":
                        {
                            var startIndex = int.Parse(commands[2]);
                            var count = int.Parse(commands[4]);

                            if(!IsValid(stringList, startIndex, count))
                            {
                                Console.WriteLine("Invalid input parameters.");
                                continue;
                            }

                            stringList.Reverse(startIndex, count);
                            break;
                        }

                    case "sort":
                        {
                            var startIndex = int.Parse(commands[2]);
                            var count = int.Parse(commands[4]);

                            if (!IsValid(stringList, startIndex, count))
                            {
                                Console.WriteLine("Invalid input parameters.");
                                continue;
                            }

                            stringList.Sort(startIndex, count, null);
                            break;
                        }

                    case "rollLeft":
                        {
                            var count = int.Parse(commands[1]);

                            if(count < 0)
                            {
                                Console.WriteLine("Invalid input parameters.");
                                continue;
                            }

                            RollLeft(stringList, count);
                            break;
                        }

                    case "rollRight":
                        {
                            var count = int.Parse(commands[1]);

                            if (count < 0)
                            {
                                Console.WriteLine("Invalid input parameters.");
                                continue;
                            }

                            RollRight(stringList, count);
                            break;
                        }

                    default:
                        break;
                }

            }

            Console.WriteLine("[{0}]", string.Join(", ", stringList));
        }

        public static bool IsValid(List<string> stringList, int startIndex, int count)
        {
            if (0 <= startIndex && startIndex < stringList.Count &&
                0 <= count && (startIndex + count) <= stringList.Count)
                return true;

            return false;
        }

        public static void RollLeft(List<string> stringList, int count)
        {
            stringList.Reverse();
            RollRight(stringList, count);
            stringList.Reverse();
        }

        public static void RollRight(List<string> stringList, int count)
        {
            var len = stringList.Count;

            var tempList = new string[len];
            stringList.CopyTo(tempList);

            for (int i = 0; i < len; i++)
            {
                var newIndex = (i + count) % len;

                stringList[newIndex] = tempList[i];
            }
        }
    }
}
