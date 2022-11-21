using ShuInkWeb.Core.Models.MerchandiseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Contracts
{
    public interface IMerchandiseService
    {
        public Task<IEnumerable<MerchandiseViewModel>> GetAllMerchandisesAsync();

        public Task AddMerchandiseAsync(MerchandiseViewModel model);
    }
}
