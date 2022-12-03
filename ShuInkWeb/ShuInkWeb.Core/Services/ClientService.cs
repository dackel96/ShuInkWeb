using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IDeletableEntityRepository<Client> repository;

        public ClientService(IDeletableEntityRepository<Client> _repository)
        {
            repository = _repository;
        }
        public Task<Client> GetClientById(Guid id)
        {
            return repository.GetByIdAsync(id);
        }
    }
}
