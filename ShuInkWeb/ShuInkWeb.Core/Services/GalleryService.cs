using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
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

        private readonly IDeletableEntityRepository<Artist> artistRepository;

        private readonly IOldCapitalCloud cloud;

        private readonly IGuard guard;

        private readonly ILogger<GalleryService> logger;

        public GalleryService(IDeletableEntityRepository<Image> _imageRepository,
            IDeletableEntityRepository<Artist> _artistRepository,
            IOldCapitalCloud _cloud,
            IGuard _guard,
            ILogger<GalleryService> _logger)
        {
            imageRepository = _imageRepository;
            artistRepository = _artistRepository;
            cloud = _cloud;
            guard = _guard;
            logger = _logger;
        }

        public async Task AddAsync(ImageViewModel model, IFormFile file)
        {
            await cloud.UploadFile(file, model.Title);

            var url = cloud.GetUrl(model.Title);

            var image = new Image()
            {
                ArtistId = model.ArtistId,
                Title = model.Title,
                ImageUrl = url != null ? url : "https://res.cloudinary.com/oldcapitalcloud/image/upload/v1671146726/Novi%20Ceni%20ot%202023.png"
            };

            try
            {
                await imageRepository.AddAsync(image);

                await imageRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(AddAsync), ex);
                throw new ApplicationException("Database failed to Add Photo!", ex);
            }
        }

        public async Task<IEnumerable<ImageViewModel>> GetAllPhotosAsync()
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

        public async Task<IEnumerable<ImageViewModel>> GetAllPhotosForAnArtistAsync(Guid artistId)
        {
            var artist = await artistRepository.GetByIdAsync(artistId);

            guard.AgainstNull(artist, "Artist Doe's Not Exists!");

            var photos = await imageRepository.AllAsNoTracking()
                .Where(x => x.ArtistId == artistId)
               .OrderByDescending(x => x.CreatedOn)
               .Select(x => new ImageViewModel()
               {
                   Id = x.Id,
                   Title = x.Title,
                   ImageUrl = x.ImageUrl
               })
               .ToListAsync();

            return photos;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await imageRepository.GetByIdAsync(id);

            guard.AgainstNull(entity, "This Photo Doe's Not Exists!");

            try
            {
                imageRepository.Delete(entity);

                await imageRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(DeleteAsync), ex);
                throw new ApplicationException("Database failed to Delete Photo!", ex);
            }
        }

        public async Task EditAsync(Guid id, ImageViewModel model, IFormFile file)
        {
            var entity = await imageRepository.GetByIdAsync(id);

            guard.AgainstNull(entity, "This Photo Doe's Not Exists!");

            if (model == null)
            {
                throw new ApplicationException("Model is Empty!");
            }

            try
            {

                await cloud.UploadFile(file, model.Title);

                var url = cloud.GetUrl(model.Title);


                entity.Title = model.Title;
                entity.ImageUrl = url != null ? url : "https://res.cloudinary.com/oldcapitalcloud/image/upload/v1671146726/Novi%20Ceni%20ot%202023.png";

                await imageRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(EditAsync), ex);
                throw new ApplicationException("Database failed to Edit Photo!", ex);
            }
        }

        public async Task<IEnumerable<ImageViewModel>> GetLastFivePhotosAsync()
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

        public async Task<ImageViewModel> GetSinglePhotoAsync(Guid id)
        {
            var entity = await imageRepository.GetByIdAsync(id);

            guard.AgainstNull(entity, "This Photo Doe's Not Exists!");

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

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await imageRepository.AllAsNoTracking()
                .AnyAsync(x => x.Id == id);
        }
    }
}
