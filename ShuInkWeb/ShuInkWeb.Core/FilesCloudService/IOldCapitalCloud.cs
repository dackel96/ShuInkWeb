using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;

namespace ShuInkWeb.Core.FilesCloudService
{
    public interface IOldCapitalCloud
    {
        public Account Account { get; init; }

        public Cloudinary Cloudinary { get; init; }

        public Task UploadFile(IFormFile file, string publicId);

        public string GetUrl(string publicId);
    }
}
