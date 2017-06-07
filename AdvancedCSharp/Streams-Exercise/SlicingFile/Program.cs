using System;
using System.Collections.Generic;
using System.IO;

namespace SlicingFile
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Choose file path: ");
            var filePath = Console.ReadLine()
                .Trim('"');

            Console.Write("Choose number of parts to slice the file: ");
            var parts = int.Parse(Console.ReadLine());

            var ext = Path.GetExtension(filePath);

            var dir = Path.GetDirectoryName(filePath);
            dir += Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filePath);

            Directory.CreateDirectory(dir);

            var fileList = SliceFilesIntoParts(filePath, dir, ext, parts);

            AssembleFileFromParts(fileList, dir, ext);
        }

        private static List<string> SliceFilesIntoParts(string filePath, string destinationDirectory, string ext, int parts)
        {
            var fileList = new List<string>();

            using (var inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var index = 0;
                var partSize = (int)(inputStream.Length / parts);

                while (index < parts)
                {
                    var outputFile = string.Format("{0}{1}Part-{2}{3}", destinationDirectory, Path.DirectorySeparatorChar, index, ext);
                    fileList.Add(outputFile);

                    using (var outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                    {
                        var buffer = new byte[partSize];
                        var readBytes = inputStream.Read(buffer, 0, partSize);

                        outputStream.Write(buffer, 0, readBytes);
                    }

                    index++;
                }
            }

            return fileList;
        }

        private static void AssembleFileFromParts(List<string> fileList, string destinationDirectory, string ext)
        {
            var outputFile = string.Format("{0}{1}assebmled{2}", destinationDirectory, Path.DirectorySeparatorChar, ext);

            using (var outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                foreach (var filePath in fileList)
                {
                    using (var inputFile = new FileStream(filePath, FileMode.Open, FileAccess.Read))

                        while (true)
                        {
                            var buffer = new byte[4096];
                            var readBytes = inputFile.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                                break;

                            outputStream.Write(buffer, 0, readBytes);
                        }
                }
            }
        }
    }
}
