using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities.Artists;

namespace ShuInkWeb.Core.Contracts
{
    public interface IAppointmentService
    {
        public Task AddAppointmentAsync(AppointmentViewModel model);

        public Task<IEnumerable<AppointmentShareModel>> GetAppointmentsAsync();

        public Task<AppointmentViewModel> FindByIdAsync(Guid id);
    }
}
