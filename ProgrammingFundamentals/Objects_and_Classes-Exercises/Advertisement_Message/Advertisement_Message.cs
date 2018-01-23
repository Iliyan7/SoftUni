using System;

namespace Advertisement_Message
{
    public class Advertisement_Message
    {
        public static void Main()
        {
            string[] phrases = new string[]
           {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] author = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            string[] cities = new string[] { "Burgas", "Sofia", "Plovidv", "Varna", "Ruse" };

            Random rnd = new Random();

            Console.WriteLine("{0} {1} {2} - {3}",
                phrases[rnd.Next(0, phrases.Length)],
                events[rnd.Next(0, events.Length)],
                author[rnd.Next(0, author.Length)],
                cities[rnd.Next(0, cities.Length)]);
        }
    }
}
