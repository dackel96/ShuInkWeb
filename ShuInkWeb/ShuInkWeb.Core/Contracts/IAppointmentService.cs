using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities;

namespace ShuInkWeb.Core.Contracts
{
    public interface IAppointmentService
    {
        public Task AddAsync(AppointmentViewModel model, Guid artistId);

        public Task<IEnumerable<AppointmentShareModel>> GetAllAsync();

        public Task<bool> IsExistingAsync(Guid id);

        public Task<bool> HasArtistWithIdAsync(Guid id, string userId);

        public Task<AppointmentDetailsModel> DetailsModelByIdAsync(Guid id);

        public Task EditAsync(Guid appointmentId, AppointmentViewModel model);

        public Task<Appointment> GetEntityByIdAsync(Guid id);

        public Task DeleteAsync(Guid appointmentId);

        public Task<IEnumerable<AppointmentForCurrentArtistModel>> GetAppointmentsForCurrentArtistAsync(Guid id);

        public Task<bool> IsFreeThisHourAsync(DateTime start,DateTime end);

    }
}
