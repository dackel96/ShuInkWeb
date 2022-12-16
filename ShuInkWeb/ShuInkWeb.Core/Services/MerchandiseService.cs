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
        private readonly IDeletableEntityRepository<Merchandise> merchandiseRepository;

        private readonly IDeletableEntityRepository<MerchandiseType> typesRepository;

        public MerchandiseService(IDeletableEntityRepository<Merchandise> _repository, IDeletableEntityRepository<MerchandiseType> _typesRepository)
        {
            merchandiseRepository = _repository;
            typesRepository = _typesRepository;
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

            await merchandiseRepository.AddAsync(merchandise);

            await merchandiseRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MerchandiseViewModel>> GetAllMerchandisesAsync()
        {
            return await merchandiseRepository.All()
                .Select(x => new MerchandiseViewModel()
                {
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    TypeId = x.MerchandiseTypeId
                }).ToListAsync();
        }

        public async Task<IEnumerable<MerchandiseType>> GetMerchandiseTypesAsync()
        {
            return await typesRepository.AllAsNoTracking().ToListAsync();
        }
    }
}
