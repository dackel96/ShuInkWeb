using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities.Clients;

namespace ShuInkWeb.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDeletableEntityRepository<Appointment> repository;

        public AppointmentService(IDeletableEntityRepository<Appointment> _repository)
        {
            repository = _repository;
        }

        public async Task AddAppointmentAsync(AppointmentViewModel model)
        {
            var appointment = new Appointment()
            {
                Title = model.Title,
                Description = model.Description,
                Client = new Client()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    SocialMedia = model.SocialMedia
                },
                ArtistId = model.ArtistId,
                Start = model.Start,
                End = model.Start.AddHours(model.Duration),
            };


            await repository.AddAsync(appointment);
            await repository.SaveChangesAsync();
        }

        public Task<AppointmentViewModel> AppointmentInfoModelById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await repository.AllAsNoTracking().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await repository.All().ToListAsync();
        }

        public async Task<IEnumerable<AppointmentShareModel>> GetAppointmentsForTodayAsync()
        {
            return await repository.All()
                .Where(x => x.Start.Date == DateTime.Now.Date)
                .Select(x => new AppointmentShareModel()
                {
                    Title = x.Title,
                    Day = DateTime.Now.Day.ToString(),
                    Month = DateTime.Now.Month.ToString(),
                    DayOfWeek = DateTime.Now.DayOfWeek.ToString(),
                    Start = x.Start.ToShortTimeString(),
                    End = x.End.ToShortTimeString(),
                    ArtistName = x.Artist.ApplicationUser!.UserName

                }).ToListAsync();
        }

        public async Task<bool> HasArtistWithId(Guid id, string userId)
        {
            bool isTrue = false;

            var appointment = await repository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Artist)
                .FirstOrDefaultAsync();

            if (appointment?.Artist != null && appointment.Artist.ApplicationUserId == userId)
            {
                isTrue = true;
            }

            return isTrue;
        }
    }
}
