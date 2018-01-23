using System;
using System.Collections.Generic;
using System.IO;

namespace Odd_Lines
{
    public class Odd_Lines
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
            List<string> oddLines = new List<string>();

            for (int i = 1; i < lines.Length; i += 2)
            {
                oddLines.Add(lines[i]);
            }

            File.WriteAllLines(outputFile, oddLines);
        }
    }
}
