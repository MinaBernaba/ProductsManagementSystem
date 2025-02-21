
using Microsoft.AspNetCore.Http;

namespace ProductsProject.Service.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(string location, IFormFile file);
    }
}
