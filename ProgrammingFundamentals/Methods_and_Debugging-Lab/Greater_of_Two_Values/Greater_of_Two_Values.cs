using System;

namespace Greater_of_Two_Values
{
    public class Greater_of_Two_Values
    {
        public static void Main()
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int firstInput = int.Parse(Console.ReadLine());
                int secondInput = int.Parse(Console.ReadLine());
                Console.WriteLine(GetGreater(firstInput, secondInput));
            }
            else if (type == "char")
            {
                char firstInput = char.Parse(Console.ReadLine());
                char secondInput = char.Parse(Console.ReadLine());
                Console.WriteLine(GetGreater(firstInput, secondInput));
            }
            else if(type == "string")
            {
                string firstInput = Console.ReadLine();
                string secondInput = Console.ReadLine();
                Console.WriteLine(GetGreater(firstInput, secondInput));
            }
        }

        public static int GetGreater(int first, int second)
        {
            return Math.Max(first, second);
        }

        public static char GetGreater(char first, char second)
        {
            return (char)GetGreater((int)first, (int)second);
        }

        public static string GetGreater(string first, string second)
        {
            if (first.CompareTo(second) >= 0)
                return first;
            else
                return second;
        }
    }
}
