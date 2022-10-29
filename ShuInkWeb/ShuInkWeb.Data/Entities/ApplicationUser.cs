using Microsoft.AspNetCore.Identity;

namespace ShuInkWeb.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
