using System;
using System.Collections.Generic;

namespace RequestParser
{
    class Program
    {
        private static string HttpResponseTemplate = "{0} {1}\nContent-Length: {2}\nContent-Type: text/plain\n\n{3}";

        static void Main(string[] args)
        {
            var paths = new List<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                paths.Add(input);
            }

            var request = Console.ReadLine()
                .Split(' ');

            var requestMethot = request[0].ToLower();
            var requestPath = request[1];
            var requestHttpVersion = request[2];

            var responseStatusCode = 200;
            var responseStatusText = "OK";

            if (!paths.Contains($"{requestPath}/{requestMethot}"))
            {
                responseStatusCode = 404;
                responseStatusText = "Not Found";

            }

            Console.WriteLine(string.Format(HttpResponseTemplate,
                requestHttpVersion,
                $"{responseStatusCode} {responseStatusText}",
                responseStatusText.Length,
                responseStatusText));
        }
    }
}
