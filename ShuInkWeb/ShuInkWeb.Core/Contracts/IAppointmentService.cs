using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Contracts
{
    public interface IAppointmentService
    {
        public Task AddAppointmentAsync(AddAppointmentViewModel model);

        public Task<IEnumerable<Artist>> GetArtistsAsync();

        public Task<IEnumerable<AppointmentViewModel>> GetAllAppointmentsAsync();
    }
}
