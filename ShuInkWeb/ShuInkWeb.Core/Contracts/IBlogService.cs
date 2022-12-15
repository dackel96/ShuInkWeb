using Microsoft.AspNetCore.Http;
using ShuInkWeb.Core.Models.HappeningModels;

namespace ShuInkWeb.Core.Contracts
{
    public interface IBlogService
    {
        public Task<IEnumerable<HappeningViewModel>> GetPostsAsync();

        public Task<IEnumerable<HappeningViewModel>> GetPostsForAnArtistAsync(Guid id);

        public Task AddAsync(HappeningViewModel model,IFormFile file);

        public Task<bool> IsExistAsync(Guid id);

        public Task<HappeningViewModel> GetSinglePostAsync(Guid id);

        public Task EditAsync(Guid id, HappeningViewModel model,IFormFile file);

        public Task DeleteAsync(Guid id);
    }
}
