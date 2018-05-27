using System;
using System.Threading.Tasks;

namespace TaskTesting
{
   
    class Program
    {
        static void Main(string[] args)
        {
            RunCounter().Wait();
        }

        private static async Task RunCounter()
        {
            var count = new Counter(5);
            await count.StartCounting(8);
        }
    }
}
