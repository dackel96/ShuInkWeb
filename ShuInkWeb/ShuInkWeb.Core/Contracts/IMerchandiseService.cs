using ShuInkWeb.Core.Models.MerchandiseModels;
using ShuInkWeb.Data.Entities.Merchandises;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Contracts
{
    public interface IMerchandiseService
    {
        public Task<IEnumerable<MerchandiseViewModel>> GetAllMerchandisesAsync();

        public Task AddMerchandiseAsync(MerchandiseViewModel model);

        public Task<IEnumerable<MerchandiseType>> GetMerchandiseTypesAsync();
    }
}
