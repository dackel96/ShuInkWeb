using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
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
        private readonly IDeletableEntityRepository<Happening> repository;

        public BlogService(IDeletableEntityRepository<Happening> _repository)
        {
            this.repository = _repository;
        }

        public async Task AddHappeningAsync(HappeningViewModel model)
        {
            var happening = new Happening()
            {
                Title = model.Title,
                Content = model.Content,
                ImageUrl = model.ImageUrl
            };

            await repository.AddAsync(happening);

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
