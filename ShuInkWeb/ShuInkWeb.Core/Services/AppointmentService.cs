using ShuInkWeb.Core.Contracts;

namespace ShuInkWeb.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository repository;

        public AppointmentService(IRepository _repository)
        {
            repository = _repository;
        }

        
    }
}
