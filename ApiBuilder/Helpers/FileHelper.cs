using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBuilder.Helpers
{
    public static class FileHelper
    {
        public static DirectoryInfo GetDirectory(string directoryPath = null)
        {
            if (directoryPath is null)
                directoryPath = Directory.GetCurrentDirectory();

            var directory = new DirectoryInfo(directoryPath);

            return directory;
        }

        public static FileInfo FilePathByName(string fileName, string directoryPath = null)
        {
            var directory = GetDirectory(directoryPath);
            
            var filePath = directory.GetFiles()
                .FirstOrDefault(x => x.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));

            return filePath;
        }

        public static FileInfo FilePathByExtention(string extention, string directoryPath = null)
        {
            var directory = GetDirectory(directoryPath);

            var filePath = directory.GetFiles()
                .FirstOrDefault(x => x.Name.EndsWith(extention?.ToLower()));

            return filePath;
        }

    }
}
