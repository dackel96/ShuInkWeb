using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IDeletableEntityRepository<Client> repository;

        private readonly IDeletableEntityRepository<Appointment> appointmentRepository;

        public ClientService(IDeletableEntityRepository<Client> _repository, IDeletableEntityRepository<Appointment> _appointmentRepository)
        {
            repository = _repository;
            appointmentRepository = _appointmentRepository;
        }
        public Task<Client> GetClientById(Guid id)
        {
            return repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<AppointmentViewForClient>> GetCurrUserAppointments(string phoneNumber)
        {
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
