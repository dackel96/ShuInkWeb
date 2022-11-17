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

        public async Task<IEnumerable<AppointmentShareModel>> GetAppointmentsAsync()
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
    }
}
