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
        public Task Add(MessageViewModel model,IFormFile file);

        public Task<IEnumerable<MessageViewModel>> All();
    }
}
