using ShuInkWeb.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Services
{
    public class HappeningService : IHappeningService
    {
        private readonly IRepository repository;

        public HappeningService(IRepository _repository)
        {
            this.repository = _repository;
        }


    }
}
