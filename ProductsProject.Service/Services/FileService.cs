using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Service.Services
{
    public class FileService(IWebHostEnvironment webHostEnvironment) : IFileService
    {
        public async Task<string> UploadFileAsync(string location, IFormFile file)
        {
            var extention = Path.GetExtension(file.FileName);

            var fileName = Guid.NewGuid().ToString() + extention;

            var directoryPath = Path.Combine(webHostEnvironment.WebRootPath, location);

            var filePath = Path.Combine(directoryPath, fileName);


            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return $"/{location}/{fileName}";
        }
    }
}
