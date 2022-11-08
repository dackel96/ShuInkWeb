using Microsoft.AspNetCore.Identity;
using ShuInkWeb.Data.Entities.Artists;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShuInkWeb.Data.Constants.UserConstants;

namespace ShuInkWeb.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [MaxLength(UserSocialMediaMaxLength)]
        public string SocialMedia { get; set; } = null!;

        public virtual IEnumerable<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
