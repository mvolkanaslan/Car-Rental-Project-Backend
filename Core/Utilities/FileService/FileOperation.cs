using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileService
{
    public class FileOperation
    {
        public static string UploadImageFile(IFormFile imageFile)
        {
            var fileFormat = Path.GetExtension(imageFile.FileName).ToLower();
            var filename = Guid.NewGuid().ToString();
            var path = Path.Combine( @"wwwroot\Upload\Images\CarImages", filename + fileFormat);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            return filename+fileFormat;
        }
        public static void UpdateImageFile(IFormFile imageFile,string imagePath)
        {
            var path = Path.Combine(@"wwwroot\Upload\Images\CarImages", imagePath);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
                fileStream.Flush();
            }
        }
        public static void DeleteImageFile(string fileName)
        {
            var path = Path.Combine(@"wwwroot\Upload\Images\CarImages", fileName);
            if (File.Exists(path)) File.Delete(path);

        }
    }
}
