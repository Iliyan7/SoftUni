using System;

namespace StringLength
{
    public class Program
    {
        private const int MaxChars = 20;

        public static void Main()
        {
            var input = Console.ReadLine();

            if (input.Length > MaxChars)
            {
                input = input.Remove(20);
            }
            else if(input.Length < MaxChars)
            {
                input = input.PadRight(MaxChars, '*');
            }

            Console.WriteLine(input);
        }
    }
}

