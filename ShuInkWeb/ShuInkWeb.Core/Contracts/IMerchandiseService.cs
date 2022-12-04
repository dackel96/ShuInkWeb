namespace ShuInkWeb.Core.Contracts
{
    using ShuInkWeb.Core.Models.MerchandiseModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMerchandiseService
    {
        public Task<IEnumerable<MerchandiseViewModel>> GetAllMerchandisesAsync();

        public Task AddMerchandiseAsync(MerchandiseViewModel model);
    }
}
