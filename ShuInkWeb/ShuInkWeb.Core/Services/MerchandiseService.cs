using ShuInkWeb.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        private readonly IRepository repository;

        public MerchandiseService(IRepository _repository)
        {
            repository = _repository;
        }

    }
}
