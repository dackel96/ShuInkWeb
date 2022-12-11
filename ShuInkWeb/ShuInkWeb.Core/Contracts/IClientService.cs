using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities.Clients;

namespace ShuInkWeb.Core.Contracts
{
    public interface IClientService
    {
        public Task<bool> ExistById(string userId);

        public Task<Client> GetClientById(Guid id);

        public Task<IEnumerable<AppointmentViewForClient>> GetCurrUserAppointments(string phoneNumber);
    }
}
