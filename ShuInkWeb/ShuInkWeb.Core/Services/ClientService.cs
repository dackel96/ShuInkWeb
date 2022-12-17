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

        public async Task<Client> GetClientById(Guid Id)
        {
            var client = await repository.GetByIdAsync(Id);

            guard.AgainstNull(client, "This CLient Doe's Not Exists!");

            return client;
        }

        public async Task<Guid> GetClientByUserId(string id)
        {
            var client = await repository.All().FirstOrDefaultAsync(x => x.UserId == id);

            guard.AgainstNull(client, "Client Doe's Not Exists!");

            return client!.Id;
        }

        public async Task<IEnumerable<AppointmentViewForClient>> GetCurrUserAppointments(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);

            guard.AgainstNull(entity, "This User Doe's Not Exists!");

            return await appointmentRepository.AllAsNoTracking()
                .Where(x => x.ClientId == id)
                .Where(x => x.End >= DateTime.Now)
                .Select(x => new AppointmentViewForClient()
                {
                    Day = x.Start.ToShortDateString(),
                    Start = x.Start.ToShortTimeString(),
                    End = x.End.ToShortTimeString()
                }).ToListAsync();
        }
    }
}
