using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ValidUsernames
{
    public class Program
    {
        public static void Main()
        {
            var usernames = Regex.Split(Console.ReadLine(), @"[ \/\\()]");

            var validUsernames = new List<string>();
            var pattern = @"^[a-zA-Z]\w{2,24}$";

            foreach (var username in usernames)
            {
                if (Regex.IsMatch(username, pattern))
                {
                    validUsernames.Add(username);
                }
            }

            var maxLen = int.MinValue;
            var maxLenIndex = 0;

            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                var currentLen = validUsernames[i].Length + validUsernames[i + 1].Length;

                if (currentLen > maxLen)
                {
                    maxLen = currentLen;
                    maxLenIndex = i;
                }
            }

            Console.WriteLine(validUsernames[maxLenIndex]);
            Console.WriteLine(validUsernames[maxLenIndex + 1]);
        }
    }
}
