using System;

namespace Hello_Name
{
    public class Hello_Name
    {
        public static void Main()
        {
            PrintHelloName(Console.ReadLine());
        }

        public static void PrintHelloName(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
