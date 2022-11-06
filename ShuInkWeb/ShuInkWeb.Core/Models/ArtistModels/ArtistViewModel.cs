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

        public int Age { get; set; }

        [Required]
        [StringLength(ResumeMaxLength, MinimumLength = ResumeMinLength)]
        public string Resume { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMax, MinimumLength = ImageUrlMin)]
        public string imageUrl { get; set; } = null!;

        public IEnumerable<Tatto> Works { get; set; } = new HashSet<Tatto>();
    }
}
