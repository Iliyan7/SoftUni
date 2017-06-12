using System;

namespace MelrahShake
{
    public class Program
    {
        public static void Main()
        {   
            var input = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                var firstIndex = input.IndexOf(pattern);
                var lastIndex = input.LastIndexOf(pattern);

                if (firstIndex > -1 && lastIndex > -1 && pattern.Length > 0)
                {
                    input = input.Remove(firstIndex, pattern.Length);
                    input = input.Remove(lastIndex - pattern.Length, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }
            }

            Console.WriteLine(input);
        }
    }
}
