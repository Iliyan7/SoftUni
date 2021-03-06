﻿using System;
using System.Collections.Generic;

namespace Magic_exchangeable_words
{
    public class Magic_exchangeable_words
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(' ');

            Console.WriteLine(AreExchangeable(words[0], words[1]).ToString().ToLower());
        }

        public static bool AreExchangeable(string w1, string w2)
        {
            var mappedChars = new Dictionary<char, char>();

            var minLen = Math.Min(w1.Length, w2.Length);
          
            for (int i = 0; i < minLen; i++)
            {
                char c1 = w1[i];
                char c2 = w2[i];

                if (mappedChars.ContainsKey(c1))
                {
                    if (mappedChars[c1] != c2)
                        return false;
                }
                else
                {
                    if (mappedChars.ContainsValue(c2))
                        return false;

                    mappedChars.Add(c1, c2);
                }
            }

            var maxLen = Math.Max(w1.Length, w2.Length);

            if (w1.Length == w2.Length)
                return true;

            var biggestWord = w1.Length > w2.Length ? w1 : w2;

            foreach (var c in biggestWord)
            {
                if (!mappedChars.ContainsKey(c) && !mappedChars.ContainsValue(c))
                    return false;
            }

            return true;
        }
    }
}
