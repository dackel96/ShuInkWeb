using ShuInkWeb.Core.Models.HappeningModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Contracts
{
    public interface IBlogService
    {
        public Task<IEnumerable<HappeningViewModel>> GetHappeningsAsync();

        public Task AddHappeningAsync(HappeningViewModel model);
    }
}
