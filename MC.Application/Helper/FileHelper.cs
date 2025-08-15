using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Helper
{
    public static class FileHelper
    {
        public static string GetFileExtension(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            var ext = Path.GetExtension(fileName);
            return ext?.ToLowerInvariant() ?? string.Empty;
        }

        public static bool IsValidFileType(string fileName, params string[] allowedExtensions)
        {
            var extension = GetFileExtension(fileName);
            return allowedExtensions.Any(e => e == extension);
        }

        public static byte[] ConvertToBytes(Stream inputStream)
        {
            using var memoryStream = new MemoryStream();
            inputStream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
