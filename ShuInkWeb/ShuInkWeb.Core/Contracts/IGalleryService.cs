using Microsoft.AspNetCore.Http;
using ShuInkWeb.Core.Models.GalleryModels;

namespace ShuInkWeb.Core.Contracts
{
    public interface IGalleryService
    {
        public Task<IEnumerable<ImageViewModel>> GetAllPhotosAsync();

        public Task<IEnumerable<ImageViewModel>> GetAllPhotosForAnArtistAsync(Guid artistId);

        public Task AddAsync(ImageViewModel model, IFormFile file);

        public Task EditAsync(Guid id, ImageViewModel model,IFormFile file);

        public Task DeleteAsync(Guid id);

        public Task<bool> IsExistAsync(Guid id);

        public Task<ImageViewModel> GetSinglePhotoAsync(Guid id);

        public Task<IEnumerable<ImageViewModel>> GetLastFivePhotosAsync();
    }
}
