using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Clients;

namespace ShuInkWeb.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IDeletableEntityRepository<Client> repository;

        private readonly IDeletableEntityRepository<Appointment> appointmentRepository;

        private readonly ILogger<ClientService> logger;

        private readonly IGuard guard;

        public ClientService(IDeletableEntityRepository<Client> _repository,
            IDeletableEntityRepository<Appointment> _appointmentRepository,
            IGuard _guard,
            ILogger<ClientService> _logger)
        {
            repository = _repository;
            appointmentRepository = _appointmentRepository;
            guard = _guard;
            logger = _logger;
        }

        public async Task<bool> ExistById(string userId)
        {
            return await repository.All()
                .AnyAsync(x => x.UserId == userId);
        }

        public async Task<Client> GetClientById(Guid id)
        {
            var client = await repository.GetByIdAsync(id);

            guard.AgainstNull(client, "Client Doe's Not Exists!");

            return client;
        }

        public async Task<IEnumerable<AppointmentViewForClient>> GetCurrUserAppointments(string phoneNumber)
        {
            guard.AgainstNull(phoneNumber, "This PhoneNumber Doe's Not Exists!");

            return await appointmentRepository.AllAsNoTracking()
                 .Where(x => x.Client.PhoneNumber == phoneNumber)
                 .Where(x => x.Start >= DateTime.Now)
                 .Select(x => new AppointmentViewForClient()
                 {
                     ArtistName = x.Artist.ApplicationUser!.FirstName!,
                     Day = x.Start.ToShortDateString(),
                     Start = x.Start.ToShortTimeString(),
                     End = x.End.ToShortTimeString()
                 }).ToListAsync();
        }
    }
}
