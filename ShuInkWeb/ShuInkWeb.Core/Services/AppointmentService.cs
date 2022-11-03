using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository repository;

        public AppointmentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAppointmentAsync(AddAppointmentViewModel model)
        {
            var appointment = new Appointment()
            {
                Title = model.Title,
                Description = model.Description,
                ArtistId = model.ArtistId,
                DurationTime = model.Duration,
                Beginning = DateTime.Parse(model.Beginning),
                User = new ApplicationUser()
                {
                    FirstName = model.Client.FirstName,
                    LastName = model.Client.LastName,
                    PhoneNumber = model.Client.PhoneNumber,
                    SocialMedia = model.Client.SocialMedia
                }
            };

            await repository.AddAsync(appointment);

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetAllAppointmentsAsync()
        {
            var appointments = await repository.All<Appointment>().ToListAsync();

            return appointments
                .Select(x => new AppointmentViewModel()
                {
                    Start = x.Beginning.ToString(),
                    End = x.Beginning.AddHours(x.DurationTime).ToString(),
                    Title = x.Title
                });
        }

        public async Task<IEnumerable<Artist>> GetArtistsAsync()
        {
            return await repository.All<Artist>().ToListAsync();
        }
    }
}
