namespace ShuInkWeb.Core.Contracts
{
    using ShuInkWeb.Data.Entities.Clients;

    public interface IClientService
    {
        public Task<Client> GetClientById(Guid id);
    }
}
