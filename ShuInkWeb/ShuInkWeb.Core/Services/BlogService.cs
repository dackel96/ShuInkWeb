using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.FilesCloudService;
using ShuInkWeb.Core.Models.HappeningModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;

namespace ShuInkWeb.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IOldCapitalCloud cloud;

        private readonly IDeletableEntityRepository<Happening> postRepository;

        private readonly IDeletableEntityRepository<Artist> artistRepository;

        private readonly ILogger<BlogService> logger;

        private readonly IGuard guard;

        public BlogService(IDeletableEntityRepository<Happening> _repository,
            IOldCapitalCloud _cloud,
            ILogger<BlogService> _logger,
            IGuard _guard,
            IDeletableEntityRepository<Artist> _artistRepository)
        {
            postRepository = _repository;
            cloud = _cloud;
            logger = _logger;
            guard = _guard;
            artistRepository = _artistRepository;
        }

        public async Task AddAsync(HappeningViewModel model, IFormFile file)
        {
            await cloud.UploadFile(file, model.Title);

            var happening = new Happening()
            {
                ArtistId = model.ArtistId,
                Title = model.Title,
                Content = model.Content,
                ImageUrl = cloud.GetUrl(model.Title)
            };

            try
            {
                await postRepository.AddAsync(happening);

                await postRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(AddAsync), ex);
                throw new ApplicationException("Database failed to Add Post!", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await postRepository.GetByIdAsync(id);

            guard.AgainstNull(entity, "This Post Doe's Not Exist!");


            try
            {
                postRepository.Delete(entity);

                await postRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(DeleteAsync), ex);
                throw new ApplicationException("Database failed to Delete Post!", ex);
            }
        }

        public async Task EditAsync(Guid id, HappeningViewModel model, IFormFile file)
        {
            await cloud.UploadFile(file, model.Title);

            var post = await postRepository.GetByIdAsync(id);

            guard.AgainstNull(post, "This Post Doe's Not Exists!");
            try
            {

                post.Title = model.Title;
                post.Content = model.Content;
                post.ImageUrl = cloud.GetUrl(model.Title);

                await postRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(EditAsync), ex);
                throw new ApplicationException("Database failed to Edit Current Post!", ex);
            }
        }

        public async Task<IEnumerable<HappeningViewModel>> GetPostsAsync()
        {
            return await postRepository.AllAsNoTracking()
                .Select(x => new HappeningViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<HappeningViewModel>> GetPostsForAnArtistAsync(Guid id)
        {
            var artist = await artistRepository.GetByIdAsync(id);

            guard.AgainstNull(artist, "Artist Doe's Not Exists!");

            return await postRepository.AllAsNoTracking()
                .Where(x => x.ArtistId == id)
                .Select(x => new HappeningViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<HappeningViewModel> GetSinglePostAsync(Guid id)
        {
            var post = await postRepository.GetByIdAsync(id);

            guard.AgainstNull(post, "This Post Doe's Not Exists!");

            var model = await postRepository.All()
                .Where(x => x.Id == id)
                 .Select(x => new HappeningViewModel()
                 {
                     Title = x.Title,
                     Content = x.Content,
                     ImageUrl = x.ImageUrl
                 })
                 .FirstOrDefaultAsync();

            return model!;
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await postRepository.AllAsNoTracking()
                .AnyAsync(x => x.Id == id);
        }
    }
}
