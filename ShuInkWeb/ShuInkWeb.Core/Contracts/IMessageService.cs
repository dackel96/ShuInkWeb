using Microsoft.AspNetCore.Http;
using ShuInkWeb.Core.Models.MessageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Contracts
{
    public interface IMessageService
    {
        public Task AddAsync(MessageViewModel model,IFormFile file);

        public Task<IEnumerable<MessageViewModel>> GetAllMessagesAsync();

        public Task DeleteAsync(Guid id);

        public Task<bool> IsExistByIdAsync(Guid id);
    }
}
