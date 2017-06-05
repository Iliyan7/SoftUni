using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main()
        {
            using(var reader = new StreamReader("../../input.txt"))
            using(var writer = new StreamWriter("../../output.txt"))
            {
                var count = 1;
                var line = reader.ReadLine();

                while(line != null)
                {
                    writer.WriteLine("{0}. {1}", count++, line);

                    line = reader.ReadLine();
                }
            }
        }
    }
}
