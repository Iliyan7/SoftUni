using System;
using System.IO;

namespace OddLines
{
    public class Program
    {
        public static void Main()
        {
            using(var reader = new StreamReader("../../file.txt"))
            {
                var count = 1;
                var line = reader.ReadLine();

                while(line != null)
                {
                    if (count++ % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
