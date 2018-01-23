using System;
using System.Collections.Generic;
using System.IO;

namespace Merge_Files
{
    public class Merge_Files
    {
        public static void Main()
        {
            string fileOne = "FileOne.txt";
            string fileTwo = "FileTwo.txt";
            string outputFile = "output.txt";

            char[] newLine = new char[] { '\r', '\n' };
            string[] contentsOne = File.ReadAllText(fileOne).Split(newLine, StringSplitOptions.RemoveEmptyEntries);
            string[] contentsTwo = File.ReadAllText(fileTwo).Split(newLine, StringSplitOptions.RemoveEmptyEntries);

            List<string> mergedContents = new List<string>();

            FillList(mergedContents, contentsOne, contentsOne.Length);
            FillList(mergedContents, contentsTwo, contentsTwo.Length);

            mergedContents.Sort();

            List<string> sortedContents = new List<string>();

            foreach (string item in mergedContents)
            {
                sortedContents.Add(item);
            }

            File.WriteAllLines(outputFile, sortedContents);
        }

        public static void FillList(List<string> list, string[] arr, int len)
        {
            for (int i = 0; i < len; i++)
            {
                list.Add(arr[i]);
            }
        }
    }
}
