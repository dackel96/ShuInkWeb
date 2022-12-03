using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Core.Models.ClientModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities.Clients;
using ShuInkWeb.Data.Entities.Identities;

namespace ShuInkWeb.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDeletableEntityRepository<Appointment> repository;

        private readonly IClientService clientService;

        public AppointmentService(IDeletableEntityRepository<Appointment> _repository, IClientService _clientService)
        {
            repository = _repository;
            clientService = _clientService;
        }

        public async Task AddAppointmentAsync(AppointmentViewModel model, Guid artistId)
        {
            var appointment = new Appointment()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                ArtistId = artistId,
                Client = new Client()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    SocialMedia = model.SocialMedia
                },
                Start = model.Start,
                End = model.Start.AddHours(model.Duration),
            };


            await repository.AddAsync(appointment);
            await repository.SaveChangesAsync();
        }

        public async Task<AppointmentDetailsModel> AppointmentInfoModelById(Guid id)
        {
            return await repository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new AppointmentDetailsModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Start = x.Start,
                    End = x.End,
                    ClientFirstName = x.Client.FirstName,
                    ClientLastName = x.Client.LastName,
                    PhoneNumber = x.Client.PhoneNumber,
                    SocialMedia = x.Client.SocialMedia,
                    ArtistName = x.Artist.ApplicationUser!.FirstName
                })
                .FirstAsync();
        }

        public async Task DeleteAppointment(Guid appointmentId)
        {
            var entity = await repository.GetByIdAsync(appointmentId);

            repository.Delete(entity);

            await repository.SaveChangesAsync();
        }

        public async Task Edit(Guid appointmentId, AppointmentViewModel model)
        {
            var appointment = await repository.GetByIdAsync(appointmentId);

            var client = await clientService.GetClientById(appointment.ClientId);

            appointment.Title = model.Title;
            appointment.Description = model.Description;
            appointment.Start = model.Start;
            appointment.End = model.Start.AddHours(model.Duration);
            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.PhoneNumber = model.PhoneNumber;
            client.SocialMedia = model.SocialMedia;

            await repository.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await repository.AllAsNoTracking().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await repository.All().ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<AppointmentShareModel>> GetAppointmentsForTodayAsync()
        {
            return await repository.All()
                .Where(x => x.Start.Date == DateTime.Now.Date)
                .Select(x => new AppointmentShareModel()
                {
                    Id = x.Id,
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
