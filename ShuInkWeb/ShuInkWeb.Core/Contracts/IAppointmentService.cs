using ShuInkWeb.Core.Models.AppointmentModels;
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
    }
}
