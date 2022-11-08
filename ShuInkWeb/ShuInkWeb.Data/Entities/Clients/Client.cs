using ShuInkWeb.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShuInkWeb.Data.Constants.UserConstants;

namespace ShuInkWeb.Data.Entities.Clients
{
    public class Client : BaseEntity
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [MaxLength(UserSocialMediaMaxLength)]
        public string? SocialMedia { get; set; }

        [Required]
        [MaxLength(PhoneNumberLength)]
        [RegularExpression(PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;

        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
