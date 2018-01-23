using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Line_Numbers
{
    public class Line_Numbers
    {
        public static void Main()
        {
            string inputFile = "Input.txt";
            string outputFile = "Output.txt";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("The file doesn't exist!");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);
            List<string> numberedLines = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string numberedLine = string.Format("{0}. {1}", i + 1, lines[i]);
                numberedLines.Add(numberedLine);
            }

            File.WriteAllLines(outputFile, numberedLines);
        }
    }
}
