using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;

namespace ShuInkWeb.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDeletableEntityRepository<Appointment> repository;

        public AppointmentService(IDeletableEntityRepository<Appointment> _repository)
        {
            repository = _repository;
        }

        
    }
}
