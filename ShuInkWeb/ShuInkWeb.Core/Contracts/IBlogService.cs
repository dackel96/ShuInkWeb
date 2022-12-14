using Microsoft.AspNetCore.Http;
using ShuInkWeb.Core.Models.HappeningModels;

namespace ShuInkWeb.Core.Contracts
{
    public interface IBlogService
    {
        public Task<IEnumerable<HappeningViewModel>> GetHappeningsAsync();

        public Task AddHappeningAsync(HappeningViewModel model,IFormFile file);

        public Task<bool> HappeningExist(Guid id);

        public Task<HappeningViewModel> GetSingleHappeningAsync(Guid id);

        public Task Edit(Guid id, HappeningViewModel model,IFormFile file);

        public Task Delete(Guid id);
    }
}
