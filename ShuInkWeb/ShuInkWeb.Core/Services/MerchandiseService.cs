using ShuInkWeb.Core.Contracts;
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

    }
}
