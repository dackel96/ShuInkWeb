using Microsoft.AspNetCore.Http;
using ShuInkWeb.Core.Models.GalleryModels;

namespace ShuInkWeb.Core.Contracts
{
    public interface IGalleryService
    {
        public Task<IEnumerable<ImageViewModel>> AllPhotos();

        public Task<IEnumerable<ImageViewModel>> AllPhotosForAnArtist(Guid Artistid);

        public Task Add(ImageViewModel model, IFormFile file);

        public Task Edit(Guid id, ImageViewModel model,IFormFile file);

        public Task Delete(Guid id);

        public Task<bool> IsExist(Guid id);

        public Task<ImageViewModel> GetSingleImage(Guid id);

        public Task<IEnumerable<ImageViewModel>> GetLastAdded();
    }
}
