using System;
using System.IO;

namespace Folder_Size
{
    public class Folder_Size
    {
        public static void Main()
        {
            string testFolderOneDir = string.Format("{0}\\TestFolder", Directory.GetCurrentDirectory());
            string testFolderTwoDir = string.Format("{0}\\TestFolder2", testFolderOneDir);

            DirectoryInfo dirInfo = new DirectoryInfo(testFolderOneDir);
            FileInfo[] filesInFirstFolder = dirInfo.GetFiles();

            dirInfo = new DirectoryInfo(testFolderTwoDir);
            FileInfo[] filesInSecondFolder = dirInfo.GetFiles();

            decimal size = GetSize(filesInFirstFolder) + GetSize(filesInSecondFolder);

            Console.WriteLine(size);
        }

        public static decimal GetSize(FileInfo[] files)
        {
            long size = 0;

            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            return (size / (decimal)(1024.0 * 1024));
        }
    }
}
