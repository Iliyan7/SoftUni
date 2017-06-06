using System;
using System.Linq;

namespace ParseURLs
{
    public class Program
    {
        public static void Main()
        {
            var url = Console.ReadLine();

            var urlArgs = url
                .Split(new string[] { "://" }, StringSplitOptions.None);

            if (urlArgs.Length != 2 || !urlArgs[1].Contains('/'))
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            var index = urlArgs[1].IndexOf('/');

            var protocol = urlArgs[0];
            var server = urlArgs[1].Substring(0, index);
            var resources = urlArgs[1].Substring(index + 1);

            Console.WriteLine("Protocol = {0}", protocol);
            Console.WriteLine("Server = {0}", server);
            Console.WriteLine("Resources = {0}", resources);
        }
    }
}
