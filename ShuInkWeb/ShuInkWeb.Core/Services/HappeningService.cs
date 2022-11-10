using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Services
{
    public class HappeningService : IHappeningService
    {
        private readonly IDeletableEntityRepository<Happening> repository;

        public HappeningService(IDeletableEntityRepository<Happening> _repository)
        {
            this.repository = _repository;
        }


    }
}
