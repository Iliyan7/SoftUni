using System;

namespace Telephony
{
    class Program
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine()
                .Split(' ');

            var sites = Console.ReadLine()
                .Split(' ');

            var smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(phoneNumber));
            }

            foreach (var site in sites)
            {
                Console.WriteLine(smartphone.Browse(site));
            }
        }
    }
}
