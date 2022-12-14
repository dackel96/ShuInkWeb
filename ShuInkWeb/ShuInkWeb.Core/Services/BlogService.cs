using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.FilesCloudService;
using ShuInkWeb.Core.Models.HappeningModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IOldCapitalCloud cloud;

        private readonly IDeletableEntityRepository<Happening> repository;

        public BlogService(IDeletableEntityRepository<Happening> _repository,IOldCapitalCloud _cloud)
        {
            this.repository = _repository;
            cloud = _cloud;
        }

        public async Task AddHappeningAsync(HappeningViewModel model,IFormFile file)
        {
            await cloud.UploadFile(file, model.Title);

            var happening = new Happening()
            {
                Title = model.Title,
                Content = model.Content,
                ImageUrl = cloud.GetUrl(model.Title)
            };

            await repository.AddAsync(happening);

            await repository.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);

            repository.Delete(entity);

            await repository.SaveChangesAsync();
        }

        public async Task Edit(Guid id, HappeningViewModel model, IFormFile file)
        {
            await cloud.UploadFile(file, model.Title);

            var post = await repository.GetByIdAsync(id);

            post.Title = model.Title;
            post.Content = model.Content;
            post.ImageUrl = cloud.GetUrl(model.Title);

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<HappeningViewModel>> GetHappeningsAsync()
        {
            return await repository.All()
                .Select(x => new HappeningViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<HappeningViewModel> GetSingleHappeningAsync(Guid id)
        {
            var model = await repository.All()
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

        public async Task<bool> HappeningExist(Guid id)
        {
            return await repository.AllAsNoTracking().AnyAsync(x => x.Id == id);
        }
    }
}
