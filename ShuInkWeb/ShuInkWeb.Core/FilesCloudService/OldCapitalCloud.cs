using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ShuInkWeb.Core.FilesCloudService
{
    public class OldCapitalCloud : IOldCapitalCloud
    {
        private readonly IConfiguration configuration;

        private readonly ICloudinarySettings settings;

        public OldCapitalCloud(IConfiguration _configuration)
        {
            configuration = _configuration;

            settings = configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();

            Account = new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);

            Cloudinary = new Cloudinary(Account);
        }

        public Account Account { get; init; }
        public Cloudinary Cloudinary { get; init; }

        public string GetUrl(string publicId)
        {
            return this.Cloudinary.Api.UrlImgUp.Secure(true).BuildUrl(publicId);
        }

        public async Task UploadFile(IFormFile file, string publicId)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadResource = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        PublicId = publicId
                    };

                    uploadResult = await Cloudinary.UploadAsync(uploadResource);
                }
            }
        }


    }
}
