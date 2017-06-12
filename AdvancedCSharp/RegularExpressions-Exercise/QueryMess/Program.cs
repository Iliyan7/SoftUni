using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QueryMess
{
    public class Program
    {
        public static void Main()
        {
            var outputQueries = new Dictionary<string, List<string>>();

            var line = String.Empty;
            while ((line = Console.ReadLine()) != "END")
            {
                var queries = Regex.Split(line, @"&");

                foreach (var query in queries)
                {
                    var regex = new Regex(@"(?>.+\?)?(.+)=(.+)");
                    var match = regex.Match(query);

                    var replacedKey = Regex.Replace(match.Groups[1].Value, @"(\+|%20)", " ");
                    var replacedValue = Regex.Replace(match.Groups[2].Value, @"(\+|%20)", " ");

                    var key = string.Join(" ", replacedKey.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    var value = string.Join(" ", replacedValue.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                    if (!outputQueries.ContainsKey(key))
                    {
                        outputQueries.Add(key, new List<string> { value });
                    }
                    else
                    {
                        outputQueries[key].Add(string.Join(" ", value));
                    }
                }

                var outputQuery = String.Empty;
                foreach (var pair in outputQueries)
                {
                    outputQuery += String.Format("{0}=[{1}]", pair.Key, string.Join(", ", pair.Value));
                }
                Console.WriteLine(outputQuery);
                outputQueries.Clear();
            }
        }
    }
}
