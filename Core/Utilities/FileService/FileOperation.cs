using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileService
{
    public class FileOperation
    {
        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        static string path = @"Upload\Images\CarImages\";

        

        public static string UploadImageFile(IFormFile imageFile)
        {
            string fileFormat = Path.GetExtension(imageFile.FileName).ToLower();
            string fileName = Guid.NewGuid().ToString();
            string imagePath = Path.Combine( directory+path, fileName + fileFormat);
            if (!Directory.Exists(directory+path))
            {
                Directory.CreateDirectory(directory + path);
            }
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            //return fileName + fileFormat;
            return path.Replace(@"\","/") + fileName + fileFormat;
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
