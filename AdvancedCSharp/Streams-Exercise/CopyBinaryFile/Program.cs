using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main()
        {
            using (var inputFile = new FileStream("../../input.png", FileMode.Open, FileAccess.Read))
            using (var outputFile = new FileStream("../../output.png", FileMode.Create, FileAccess.Write))
            {
                while (true)
                {
                    var buffer = new byte[4096];
                    var readBytes = inputFile.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0)
                        break;

                    outputFile.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}
