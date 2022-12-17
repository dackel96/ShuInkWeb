using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities.Clients;

namespace ShuInkWeb.Core.Contracts
{
    public interface IClientService
    {
        public Task<bool> ExistById(string userId);

        public Task<Guid> GetClientByUserId(string id);

        public Task<Client> GetClientById(Guid Id);

        public Task<IEnumerable<AppointmentViewForClient>> GetCurrUserAppointments(Guid id);
    }
}
