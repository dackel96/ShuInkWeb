using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.MerchandiseModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Merchandises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        private readonly IDeletableEntityRepository<Merchandise> repository;

        public MerchandiseService(IDeletableEntityRepository<Merchandise> _repository)
        {
            repository = _repository;
        }

        public async Task AddMerchandiseAsync(MerchandiseViewModel model)
        {
            var merchandise = new Merchandise()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Description = model.Description,
                Quantity = model.Quantity,
                IsInStock = model.Quantity > 0 ? true : false,
                MerchandiseTypeId = model.TypeId
            };

            await repository.AddAsync(merchandise);

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MerchandiseViewModel>> GetAllMerchandisesAsync()
        {
            return await repository.All()
                .Select(x => new MerchandiseViewModel()
                {
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    InStock = x.IsInStock,
                    TypeId = x.MerchandiseTypeId
                }).ToListAsync();
        }
    }
}
