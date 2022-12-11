using ShuInkWeb.Core.Models.MerchandiseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Contracts
{
    public interface IMerchandiseService
    {
        public Task<IEnumerable<MerchandiseViewModel>> GetAllMerchandisesAsync();

        public Task AddMerchandiseAsync(MerchandiseViewModel model);
    }
}
