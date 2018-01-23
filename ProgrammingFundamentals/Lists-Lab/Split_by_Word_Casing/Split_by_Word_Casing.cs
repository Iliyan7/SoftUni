using System;
using System.Collections.Generic;
using System.Linq;

namespace Split_by_Word_Casing
{
    public class Split_by_Word_Casing
    {
        public static void Main()
        {
            char[] separators = new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' };

            List<string> wordsList = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> lowerCaseWords = GetLowerCaseWordsFromList(wordsList);
            List<string> upperCaseWords = GetUpperCaseWordsFromList(wordsList);
            List<string> mixedCaseWords = GetMixedCaseWordsFromList(wordsList, lowerCaseWords, upperCaseWords);

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCaseWords));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCaseWords));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCaseWords));
        }

        private static List<string> GetLowerCaseWordsFromList(List<string> wordsList)
        {
            List<string> lowerCaseList = new List<string>();

            for (int i = 0; i < wordsList.Count(); i++)
            {
                if (wordsList[i].All(x => char.IsLower(x)))
                    lowerCaseList.Add(wordsList[i]);
            }

            return lowerCaseList;
        }

        private static List<string> GetMixedCaseWordsFromList(List<string> wordsList, List<string> lowerCaseList, List<string> upperCaseList)
        {
            List<string> mixedCaseList = new List<string>();

            for (int i = 0; i < wordsList.Count(); i++)
            {
                if (!lowerCaseList.Contains(wordsList[i]) && !upperCaseList.Contains(wordsList[i]))
                    mixedCaseList.Add(wordsList[i]);
            }

            return mixedCaseList;
        }

        private static List<string> GetUpperCaseWordsFromList(List<string> wordsList)
        {
            List<string> upperCaseList = new List<string>();

            for (int i = 0; i < wordsList.Count(); i++)
            {
                if (wordsList[i].All(x => char.IsUpper(x)))
                    upperCaseList.Add(wordsList[i]);
            }

            return upperCaseList;
        }
    }
}
