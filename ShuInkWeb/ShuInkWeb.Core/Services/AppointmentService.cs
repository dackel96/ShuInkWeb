using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities.Clients;

namespace ShuInkWeb.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDeletableEntityRepository<Appointment> appointmentRepository;

        private readonly IDeletableEntityRepository<Artist> artistRepository;

        private readonly IDeletableEntityRepository<Client> clientRepository;

        private readonly IGuard guard;

        private readonly ILogger<AppointmentService> logger;

        public AppointmentService(IDeletableEntityRepository<Appointment> _repository,
            IDeletableEntityRepository<Client> _clientRepository,
            IGuard _guard,
            ILogger<AppointmentService> _logger,
            IDeletableEntityRepository<Artist> _artistRepository)
        {
            appointmentRepository = _repository;
            clientRepository = _clientRepository;
            guard = _guard;
            logger = _logger;
            artistRepository = _artistRepository;
        }

        public async Task AddAsync(AppointmentViewModel model, Guid artistId)
        {
            var artist = await artistRepository.GetByIdAsync(artistId);

            guard.AgainstNull(artist, "Artist Doe's not Exists!");

            try
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

                await appointmentRepository.AddAsync(appointment);
                await appointmentRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(AddAsync), ex);
                throw new ApplicationException("Database failed to save appointment", ex);
            }
        }

        public async Task<AppointmentDetailsModel> DetailsModelByIdAsync(Guid id)
        {
            var model = await appointmentRepository.GetByIdAsync(id);

            guard.AgainstNull(model, "This Appointment Doe's not Exists!");

            var result = await appointmentRepository.AllAsNoTracking()
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

            return result;
        }

        public async Task DeleteAsync(Guid appointmentId)
        {
            var entity = await appointmentRepository.GetByIdAsync(appointmentId);

            guard.AgainstNull(entity, "This Appointment Doe's not Exists!");

            try
            {
                appointmentRepository.Delete(entity);

                await appointmentRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(DeleteAsync), ex);

                throw new ApplicationException("Database failed to Delete Appointment!", ex);
            }
        }

        public async Task EditAsync(Guid appointmentId, AppointmentViewModel model)
        {
            var appointment = await appointmentRepository.GetByIdAsync(appointmentId);

            guard.AgainstNull(appointment, "This Appointment Doe's not Exists!");

            var client = await clientRepository.GetByIdAsync(appointment.ClientId);

            guard.AgainstNull(client, "Client Doe's not Exists!");

            try
            {
                appointment.Title = model.Title;
                appointment.Description = model.Description;
                appointment.Start = model.Start;
                appointment.End = model.Start.AddHours(model.Duration);
                client.FirstName = model.FirstName;
                client.LastName = model.LastName;
                client.PhoneNumber = model.PhoneNumber;
                client.SocialMedia = model.SocialMedia;

                await appointmentRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(EditAsync), ex);
                throw new ApplicationException("Database failed to Edit Appointment!", ex);
            }
        }

        public async Task<bool> IsExistingAsync(Guid id)
        {
            return await appointmentRepository.AllAsNoTracking()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<Appointment> GetEntityByIdAsync(Guid id)
        {
            var result = await appointmentRepository.GetByIdAsync(id);

            guard.AgainstNull(result, "This Appointment Doe's not Exists!");

            return result;
        }

        public async Task<IEnumerable<AppointmentForCurrentArtistModel>> GetAppointmentsForCurrentArtistAsync(Guid id)
        {
            var artist = await artistRepository.GetByIdAsync(id);

            guard.AgainstNull(artist, "Artist Doe's not Exists!");

            return await appointmentRepository.AllAsNoTracking()
                .Where(x => x.ArtistId == id)
                .Where(x => x.End >= DateTime.Now)
                .Select(x => new AppointmentForCurrentArtistModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Start = $"{x.Start.ToShortDateString()},{x.Start.ToShortTimeString()}",
                    End = $"{x.End.ToShortDateString()},{x.End.ToShortTimeString()}",
                    ClientContact = $"{x.Client.SocialMedia},{x.Client.PhoneNumber}"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentShareModel>> GetAllAsync()
        {
            return await appointmentRepository.AllAsNoTracking()
                .Where(x => x.Start.Date >= DateTime.Now.Date)
                .Select(x => new AppointmentShareModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Day = x.Start.Day.ToString(),
                    Month = x.Start.Month.ToString(),
                    DayOfWeek = x.Start.DayOfWeek.ToString(),
                    Start = x.Start.ToShortTimeString(),
                    End = x.End.ToShortTimeString(),
                    ArtistName = x.Artist.ApplicationUser!.UserName

                }).ToListAsync();
        }

        public async Task<bool> HasArtistWithIdAsync(Guid id, string userId)
        {
            bool isTrue = false;

            var appointment = await appointmentRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Artist)
                .FirstOrDefaultAsync();

            if (appointment?.Artist != null && appointment.Artist.ApplicationUserId == userId)
            {
                isTrue = true;
            }

            return isTrue;
        }

        public async Task<bool> IsFreeThisHourAsync(DateTime start, DateTime end)
        {
            if (await appointmentRepository.AllAsNoTracking().AnyAsync(x => (x.Start <= start && x.End > start)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
