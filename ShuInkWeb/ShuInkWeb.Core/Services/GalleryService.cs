using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.FilesCloudService;
using ShuInkWeb.Core.Models.GalleryModels;
using ShuInkWeb.Core.Models.HappeningModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities.Artists;

namespace ShuInkWeb.Core.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;

        private readonly IOldCapitalCloud cloud;

        public GalleryService(IDeletableEntityRepository<Image> _imageRepository,
            IOldCapitalCloud _cloud)
        {
            imageRepository = _imageRepository;
            cloud = _cloud;
        }

        public async Task Add(ImageViewModel model, IFormFile file)
        {
            await cloud.UploadFile(file, model.Title);

            var image = new Image()
            {
                ArtistId = model.ArtistId,
                Title = model.Title,
                ImageUrl = cloud.GetUrl(model.Title)
            };

            await imageRepository.AddAsync(image);

            await imageRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImageViewModel>> AllPhotos()
        {
            return await imageRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new ImageViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ImageViewModel>> AllPhotosForAnArtist(Guid Artistid)
        {
            var photos = await imageRepository.All()
               .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.ArtistId == Artistid)
               .Select(x => new ImageViewModel()
               {
                   Id = x.Id,
                   Title = x.Title,
                   ImageUrl = x.ImageUrl
               })
               .ToListAsync();

            return photos;
        }

        public async Task Delete(Guid id)
        {
            var entity = await imageRepository.GetByIdAsync(id);

            imageRepository.Delete(entity);

            await imageRepository.SaveChangesAsync();
        }

        public async Task Edit(Guid id, ImageViewModel model, IFormFile file)
        {
            await cloud.UploadFile(file, model.Title);

            var entity = await imageRepository.GetByIdAsync(id);

            entity.Title = model.Title;
            entity.ImageUrl = cloud.GetUrl(model.Title);

            await imageRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImageViewModel>> GetLastAdded()
        {
            return await imageRepository.All()
               .OrderByDescending(x => x.CreatedOn)
               .Select(x => new ImageViewModel()
               {
                   Id = x.Id,
                   Title = x.Title,
                   ImageUrl = x.ImageUrl
               })
               .Take(5)
               .ToListAsync();
        }

        public async Task<ImageViewModel> GetSingleImage(Guid id)
        {
            var model = await imageRepository.All()
               .Where(x => x.Id == id)
                .Select(x => new ImageViewModel()
                {
                    Title = x.Title,
                    ImageUrl = x.ImageUrl
                })
                .FirstOrDefaultAsync();

            return model!;
        }

        public async Task<bool> IsExist(Guid id)
        {
            return await imageRepository.AllAsNoTracking().AnyAsync(x => x.Id == id);
        }
    }
}
