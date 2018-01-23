using System;

namespace CustomList
{
    class Program
    {
        public static void Main()
        {
            var customList = new MyList<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var args = command.Split(' ');

                switch (args[0])
                {
                    case "Add":
                        customList.Add(args[1]);
                        break;
                    case "Remove":
                        customList.Remove(int.Parse(args[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(customList.Contains(args[1]));
                        break;
                    case "Swap":
                        customList.Swap(int.Parse(args[1]), int.Parse(args[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(customList.CountGreaterThan(args[1]));
                        break;
                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "Sort":
                        customList = Sorter.Sort(customList);
                        break;
                    case "Print":
                        foreach (var element in customList)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                }
            }
        }
    }
}
