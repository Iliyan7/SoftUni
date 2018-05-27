using System;
using System.IO;
using System.Threading.Tasks;

namespace SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Anything else?");
                var videoPath = Console.ReadLine()
                    .Trim('"');
                var destination = Console.ReadLine()
                    .Trim('"');
                var parts = int.Parse(Console.ReadLine());
                SliceAsync(@"C:\Users\iliyan\Desktop\source.mp4", @"C:\Users\iliyan\Desktop\source", 4);
                //Console.WriteLine("davai kure");
            }
        }

        private static void SliceAsync(string sourcePath, string destinationPath, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourcePath, destinationPath, parts);
            });
        }

        private static void Slice(string sourcePath, string destinationPath, int parts)
        {
            if(!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var sourceStream = new FileStream(sourcePath, FileMode.Open))
            {
                var fileInfo = new FileInfo(sourcePath);

                var partLength = (sourceStream.Length / parts) + 1;
                var currentByte = 0L;

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    var stringPath = string.Format($"{destinationPath}/Part-{currentPart}{fileInfo.Extension}");

                    using (var destStream = new FileStream(stringPath, FileMode.Create))
                    {
                        var buffer = new byte[4096];
                        while(currentByte <= partLength * currentPart)
                        {
                            var readByteCount = sourceStream.Read(buffer, 0, buffer.Length);
                            if (readByteCount == 0)
                            {
                                break;
                            }

                            destStream.Write(buffer, 0, readByteCount);
                            currentByte += readByteCount;
                        }
                    }
                }

                Console.WriteLine("Slice complete.");
            }
        }
    }
}
