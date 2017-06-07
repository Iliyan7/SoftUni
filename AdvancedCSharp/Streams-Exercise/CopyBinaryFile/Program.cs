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
            using (var inputStream = new FileStream("../../input.png", FileMode.Open, FileAccess.Read))
            using (var outputStream = new FileStream("../../output.png", FileMode.Create, FileAccess.Write))
            {
                while (true)
                {
                    var buffer = new byte[4096];
                    var readBytes = inputStream.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0)
                        break;

                    outputStream.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}
