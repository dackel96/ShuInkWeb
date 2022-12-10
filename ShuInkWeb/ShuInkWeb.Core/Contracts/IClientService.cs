namespace ShuInkWeb.Core.Contracts
{
    using ShuInkWeb.Core.Models.AppointmentModels;
    using ShuInkWeb.Data.Entities.Clients;

    public interface IClientService
    {
        public Task<Client> GetClientById(Guid id);

        public Task<IEnumerable<AppointmentViewForClient>> GetCurrUserAppointments(string phoneNumber);
    }
}
