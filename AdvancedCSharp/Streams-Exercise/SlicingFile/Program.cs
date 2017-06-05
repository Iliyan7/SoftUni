using System;
using System.IO;

namespace SlicingFile
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Choose file path: ");
            var file = Console.ReadLine();

            Console.Write("Choose number of parts to slice the file: ");
            var parts = int.Parse(Console.ReadLine());

            var fileExtension = file.Substring(file.LastIndexOf('.'));

            var dirOutput = file.Substring(0, file.Length - fileExtension.Length);

            Directory.CreateDirectory(dirOutput);

            Slice(file, dirOutput, parts);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var inputFile = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            {
                var index = 1;
                var partSize = (int)(inputFile.Length / parts);

                while (index <= parts)
                {
                    var destFile = string.Format("{0}/Part-{1}{2}", destinationDirectory, index, sourceFile.Substring(sourceFile.LastIndexOf('.')));

                    using (var outputFile = new FileStream(destFile, FileMode.Create, FileAccess.Write))
                    {
                        var buffer = new byte[partSize];
                        var readBytes = inputFile.Read(buffer, 0, partSize);

                        outputFile.Write(buffer, 0, readBytes);
                    }

                    index++;
                }
            }
        }
    }
}
