using ShuInkWeb.Data.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Contracts
{
    public interface IClientService
    {
        public Task<Client> GetClientById(Guid id);
    }
}
