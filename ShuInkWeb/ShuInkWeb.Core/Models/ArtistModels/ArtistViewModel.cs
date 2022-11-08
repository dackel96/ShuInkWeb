using ShuInkWeb.Data.Entities.Artists;
using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.UserConstants;
using static ShuInkWeb.Data.Constants.TattoConstants;
namespace ShuInkWeb.Core.Models.ArtistModels
{
    public class ArtistViewModel
    {
        [Required]
        [StringLength(UserFirstNameMaxLength + UserLastNameMaxLength, MinimumLength = UserFirstNameMinLength + UserLastNameMinLength)]
        public string FirstLastName { get; set; } = null!;

        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string NickName { get; set; } = null!;

        [Required]
        [RegularExpression(PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(UserSocialMediaMaxLength, MinimumLength = UserSocialMediaMinLength)]
        public string SocialMediaLink { get; set; } = null!;

        [Required]
        [StringLength(ResumeMaxLength, MinimumLength = ResumeMinLength)]
        public string Resume { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMax, MinimumLength = ImageUrlMin)]
        public string imageUrl { get; set; } = null!;

        public IEnumerable<Tatto> Works { get; set; } = new HashSet<Tatto>();
    }
}
