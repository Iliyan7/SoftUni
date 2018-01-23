using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Files
{
    public class Files
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var files = new List<FilesInfo>();

            for (int i = 0; i < n; i++)
            {
                var file = Console.ReadLine().Split(';');

                var filePath = file[0];
                var regex = new Regex(@"(.+)\\(.+)");
                var match = regex.Match(filePath);

                var rootName = Regex.Match(match.Groups[0].Value, @"^.+?(?=\\)").Value;
                var fileName = match.Groups[2].Value;
                var fileSize = long.Parse(file[1]);

                if (files.Any(x => x.RootName == rootName))
                {
                    var index = files.FindIndex(x => x.RootName == rootName);

                    if (files[index].FileName == fileName)
                    {
                        files[index].FileSize = fileSize;
                        continue;
                    }
                }

                files.Add(new FilesInfo() { RootName = rootName, FileName = fileName, FileSize = fileSize });
            }

            var query = Console.ReadLine().Split(' ');
            var foundQuery = false;

            foreach (var file in files.OrderByDescending(x => x.FileSize).ThenBy(x => x.FileName))
            {
                if (file.FileName.Substring(file.FileName.Length - query[0].Length) == query[0] &&
                    file.RootName == query[2])
                {
                    Console.WriteLine("{0} - {1} KB", file.FileName, file.FileSize);
                    foundQuery = true;
                }
            }

            if (!foundQuery) Console.WriteLine("No");
        }
    }
}
