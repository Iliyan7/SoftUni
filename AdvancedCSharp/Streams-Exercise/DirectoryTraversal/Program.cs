using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Directory to search: ");
            var targetDir = Console.ReadLine()
                .Trim('"');

            if (!Directory.Exists(targetDir))
            {
                Console.WriteLine("This directory doesn't exist!");
                return;
            }

            var report = new Dictionary<string, Dictionary<string, double>>();
            GetReport(report, targetDir);

            PrintReportToFile(report, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        private static void GetReport(Dictionary<string, Dictionary<string, double>> report, string targetDir)
        {
            var filePaths = Directory.GetFiles(targetDir);

            foreach (var filePath in filePaths)
            {
                var ext = Path.GetExtension(filePath);
                var nameAndExt = Path.GetFileName(filePath);

                var fi = new FileInfo(filePath);
                var size = fi.Length / 1024D;

                if(!report.ContainsKey(ext))
                {
                    report.Add(ext, new Dictionary<string, double> { { nameAndExt, size } });
                }
                else
                {
                    report[ext].Add(nameAndExt, size);
                }
            }
        }

        private static void PrintReportToFile(Dictionary<string, Dictionary<string, double>> report, string destinationDirectory)
        {
            var outputFile = string.Format("{0}{1}report.txt", destinationDirectory, Path.DirectorySeparatorChar);

            using (var outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                foreach (var group in report.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    var ext = string.Format("{0}{1}", group.Key, Environment.NewLine);

                    var buffer = Encoding.ASCII.GetBytes(ext);
                    outputStream.Write(buffer, 0, buffer.Length);

                    foreach (var file in group.Value.OrderBy(x => x.Value))
                    {
                        var line = string.Format("--{0} - {1:F1}kb{2}", file.Key, file.Value, Environment.NewLine);

                        buffer = Encoding.ASCII.GetBytes(line);
                        outputStream.Write(buffer, 0, buffer.Length);
                    } 
                }
            }
        }
    }
}
