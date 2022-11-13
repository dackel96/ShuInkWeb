using ShuInkWeb.Data.Entities.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShuInkWeb.Data.Constants.AppointmentConstants;
using static ShuInkWeb.Data.Constants.UserConstants;


namespace ShuInkWeb.Core.Models.AppointmentModels
{
    public class AppointmentViewModel
    {

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string? Description { get; set; }

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
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Range(1,6)]
        public int Duration { get; set; }

        public Guid ArtistId { get; set; }

        public IEnumerable<AppointmentArtistViewModel> Artists { get; set; } = new HashSet<AppointmentArtistViewModel>();
    }
}
