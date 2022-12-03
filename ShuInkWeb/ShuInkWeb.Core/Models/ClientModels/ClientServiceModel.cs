using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShuInkWeb.Data.Constants.UserConstants;
namespace ShuInkWeb.Core.Models.ClientModels
{
    public class ClientServiceModel
    {
        [Required]
        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength)]
        public string LastName { get; set; } = null!;

        [MaxLength(UserSocialMediaMaxLength)]
        public string? SocialMedia { get; set; }

        [Required]
        [MaxLength(PhoneNumberLength)]
        [RegularExpression(PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;
    }
}
