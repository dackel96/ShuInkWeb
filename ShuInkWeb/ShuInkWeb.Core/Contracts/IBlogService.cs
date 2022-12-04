namespace ShuInkWeb.Core.Contracts
{
    using ShuInkWeb.Core.Models.HappeningModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogService
    {
        public Task<IEnumerable<HappeningViewModel>> GetHappeningsAsync();

        public Task AddHappeningAsync(HappeningViewModel model);

        public Task<bool> HappeningExist(Guid id);

        public Task<HappeningViewModel> GetSingleHappeningAsync(Guid id);

        public Task Edit(Guid id, HappeningViewModel model);

        public Task Delete(Guid id);
    }
}
