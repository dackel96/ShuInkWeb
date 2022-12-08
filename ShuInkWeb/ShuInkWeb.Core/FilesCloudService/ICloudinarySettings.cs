namespace ShuInkWeb.Core.FilesCloudService
{
    public interface ICloudinarySettings
    {
        public string CloudName { get; init; }
        public string ApiKey { get; init; }
        public string ApiSecret { get; init; }
    }
}
