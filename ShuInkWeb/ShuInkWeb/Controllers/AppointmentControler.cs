using ShuInkWeb.Core.Contracts;

namespace ShuInkWeb.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService _appointmentService)
        {
            appointmentService = _appointmentService;
        }

        
    }
}
