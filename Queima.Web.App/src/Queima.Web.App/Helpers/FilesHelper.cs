using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Helpers
{
    public static class FilesHelper
    {
        public static bool VerifyFileSize(IFormFile file)
        {
            double fileSize = 0;
            using (var reader = file.OpenReadStream())
            {
                //get filesize in kb
                fileSize = (reader.Length / 1024);
            }

            //filesize less than 1MB => true, else => false
            return (fileSize < 1024) ? true : false;
        }
        public static bool VerifyFileExtension(string path)
        {
            var AllowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
            return AllowedExtensions.Contains(Path.GetExtension(path));
        }
    }
}
