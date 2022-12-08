namespace ShuInkWeb.Core.FilesCloudService
{
    public class CloudinarySettings : ICloudinarySettings
    {
        public string CloudName { get; init; } = null!;
        public string ApiKey { get; init; } = null!;
        public string ApiSecret { get; init; } = null!;
    }
}
