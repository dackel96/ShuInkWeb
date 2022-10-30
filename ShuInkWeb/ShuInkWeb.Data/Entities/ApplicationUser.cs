using Microsoft.AspNetCore.Identity;

namespace ShuInkWeb.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string SocialMedia { get; set; } = null!;

        public IEnumerable<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
