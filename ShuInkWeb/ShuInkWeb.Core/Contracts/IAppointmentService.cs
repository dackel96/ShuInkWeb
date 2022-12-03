using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;

namespace ShuInkWeb.Core.Contracts
{
    public interface IAppointmentService
    {
        public Task AddAppointmentAsync(AppointmentViewModel model,Guid artistId);

        public Task<IEnumerable<AppointmentShareModel>> GetAppointmentsForTodayAsync();

        public Task<IEnumerable<Appointment>> GetAllAppointments();

        
        public Task<bool> Exists(Guid id);

        public Task<bool> HasArtistWithId(Guid id, string userId);

        public Task<AppointmentDetailsModel> AppointmentInfoModelById(Guid id);

        public Task Edit(Guid appointmentId, AppointmentViewModel model);

        public Task<Appointment> GetAppointmentById(Guid id);

        public Task DeleteAppointment(Guid appointmentId);

    }
}
