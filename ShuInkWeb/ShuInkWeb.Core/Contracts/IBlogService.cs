namespace ShuInkWeb.Core.Contracts
{
    using Microsoft.AspNetCore.Http;
    using ShuInkWeb.Core.Models.HappeningModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogService
    {
        public Task<IEnumerable<HappeningViewModel>> GetHappeningsAsync();

        public Task AddHappeningAsync(HappeningViewModel model,IFormFile file);

        public Task<bool> HappeningExist(Guid id);

        public Task<HappeningViewModel> GetSingleHappeningAsync(Guid id);

        public Task Edit(Guid id, HappeningViewModel model);

        public Task Delete(Guid id);
    }
}
