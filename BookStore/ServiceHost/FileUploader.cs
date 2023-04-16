using _0_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file,string path)
        {
            if (file == null) return "";

            var directionPath = $"{_webHostEnvironment.WebRootPath}//ProductPictures//{path}";

            if (!Directory.Exists(directionPath))
                Directory.CreateDirectory(directionPath);

            var filePath = $"{directionPath}//{file.FileName}";

            using var output=File.Create(filePath);
            file.CopyTo(output);

            return $"{path}/{file.FileName}";
        }
    }
}
