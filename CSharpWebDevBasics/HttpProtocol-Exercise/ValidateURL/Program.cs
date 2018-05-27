using System;
using System.Net;

namespace ValidateURL
{
    class Program
    {
        static void Main(string[] args)
        {
            var encodedUrl = WebUtility.UrlDecode(Console.ReadLine());

            try
            {
                var uri = new Uri(encodedUrl);

                if (string.IsNullOrWhiteSpace(uri.Scheme) ||
                    string.IsNullOrWhiteSpace(uri.Host) ||
                    string.IsNullOrWhiteSpace(uri.AbsolutePath))
                {
                    throw new ArgumentException("Invalid URL");
                }

                PrintUrlParts(uri);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid URL");
            }
        }

        private static void PrintUrlParts(Uri uri)
        {
            Console.WriteLine($"Protocol: {uri.Scheme}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Path: {uri.AbsolutePath}");

            if (!string.IsNullOrEmpty(uri.Query))
            {
                Console.WriteLine($"Query: {uri.Query.Substring(1)}");
            }

            if (!string.IsNullOrEmpty(uri.Fragment))
            {
                Console.WriteLine($"Fragment: {uri.Fragment.Substring(1)}");
            }
        }
    }
}
